using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using DbMigrations.EntityModels.DataTypes;
using GoogleCalendarLayer.Models;
using GoogleCalendarLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicLayer.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly EventGoogleService _googleService;

        public EventService(IUnitOfWork unitOfWork, EventGoogleService googleService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _googleService = googleService;
            _mapper = mapper;
        }

        public async Task<EventDtoModel> GetByIdAsync(Guid id)
        {
            var eventEntity = await _unitOfWork.Events.FindByIdAsync(id);
            return _mapper.Map<EventDtoModel>(eventEntity);
        }

        public async Task<IEnumerable<EventDtoModel>> GetAllAsync()
        {
            var eventEntities = await _unitOfWork.Events.GetAllAsync();
            return _mapper.Map<IEnumerable<EventDtoModel>>(eventEntities);
        }

        public async Task<IEnumerable<EventDtoModel>> GetAllAsync(DateTime start, DateTime end, EventType type = EventType.FREE)
        {
            Expression<Func<EventEntityModel, bool>> expression = type switch
            {
                EventType.FREE => x => start <= x.StartTime && x.EndTime <= end && x.CandidateSandboxId == null,
                EventType.INTERVIEW => x => start <= x.StartTime && x.EndTime <= end && x.CandidateSandboxId != null,
                _ => x => start <= x.StartTime && x.EndTime <= end,
            };
            var eventEntities = await _unitOfWork.Events.FindByConditionAsync(expression);
            return _mapper.Map<IEnumerable<EventDtoModel>>(eventEntities);
        }

        public async Task<EventDtoModel> CreateAsync(EventDtoModel value)
        {
            var user = await GetUserAsync(value.OwnerId);
            if (await HasAnyBlockedFreeTimeAsync(value) || user == null)
            {
                return null;
            }
            EventEntityModel eventEntity = _mapper.Map<EventEntityModel>(value);
            eventEntity.Type = EventType.FREE;
            eventEntity.CandidateSandboxId = null;
            eventEntity = await _unitOfWork.Events.CreateAsync(eventEntity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<EventDtoModel>(eventEntity);
        }

        public async Task<EventDtoModel> CreateInterviewAsync(EventDtoModel value)
        {
            var owner = await GetUserAsync(value.OwnerId);
            var candidateSandbox = await GetCandidateSandboxAsync(value.CandidateSandboxId);

            if (await HasAnyBlockedInterviewTimeAsync(value) || owner == null  || candidateSandbox == null)
            {
                return null;
            }
            var candidate = candidateSandbox.Candidate;
            var googleToken = (await _unitOfWork.GoogleAccessTokens.FindByConditionAsync(x => x.UserId == owner.Id)).FirstOrDefault();
            var members = new List<EventMemberEntityModel>();
            var attendees = new List<AttendeeGoogleModel>
            {
                new AttendeeGoogleModel
                {
                    DisplayName = $"{owner.Name} {owner.Surname}",
                    Email = owner.Email,
                    Organizer = true,
                    Self = true
                },
                new AttendeeGoogleModel
                {
                    DisplayName = $"{candidate.Name} {candidate.Surname}",
                    Email = candidate.Email,
                    Organizer = false,
                    Self = false
                }
            };
            foreach (var member in value.Members)
            {
                var eventMember = new EventMemberEntityModel();
                var user = (await _unitOfWork.Users.FindByConditionAsync(x => x.Email == member.Email)).FirstOrDefault();
                if (user is not null)
                {
                    eventMember.MemberEmail = user.Email;
                    eventMember.Name = $"{user.Name} {user.Surname}";
                    eventMember.MemberRole = user.UserRoles.FirstOrDefault().FunctionalRole.Name;
                }
                else
                {
                    var other = (await _unitOfWork.Candidates.FindByConditionAsync(x => x.Email == member.Email)).FirstOrDefault();
                    if (other is not null)
                    {
                        eventMember.MemberEmail = other.Email;
                        eventMember.Name = $"{other.Name} {other.Surname}";
                        eventMember.MemberRole = "Candidate";
                    }
                    else
                    {
                        eventMember.MemberEmail = member.Email;
                        eventMember.Name = member.Name;
                        eventMember.MemberRole = "Other";
                    }
                   
                }
                var attendee = new AttendeeGoogleModel
                {
                    DisplayName = eventMember.Name,
                    Email = eventMember.MemberEmail,
                    Organizer = false,
                    Self = false
                };
                attendees.Add(attendee);
                members.Add(eventMember);
            }
           
            var eventGoogle = new EventGoogleModel()
            {
                Summary = $"#SAPExProject#Event: {value.Summary}",
                Description = value.Description,
                Start = new DateTimeGoogleModel
                {
                    DateTime = value.StartTime.ToString(),
                    TimeZone = "UTC"
                },
                End = new DateTimeGoogleModel
                {
                    DateTime = value.EndTime.ToString(),
                    TimeZone = "UTC"
                },
                Attendees = attendees
            };

            var eventEntity = _mapper.Map<EventEntityModel>(value);
            if (googleToken is not null)
            {
                eventGoogle = _googleService.Create(googleToken, eventGoogle);
                eventEntity.GoogleCalendarEventId = eventGoogle.Id;
            }

            
            eventEntity.Type = EventType.INTERVIEW;
            eventEntity = await _unitOfWork.Events.CreateAsync(eventEntity);
            members.ForEach(async x =>
            {
                x.EventId = eventEntity.Id;
                _ = await _unitOfWork.EventMembers.CreateAsync(x);
            });

            await _unitOfWork.SaveAsync();
            return _mapper.Map<EventDtoModel>(eventEntity);
        }

        public Task UpdateAsync(EventDtoModel value)
        {
            throw new NotImplementedException();
        }

        private async Task<UserEntityModel> GetUserAsync(Guid userId)
        {
            var users = await _unitOfWork.Users.FindByConditionAsync(x=>x.Id == userId);
            return users.FirstOrDefault();
        }

        private async Task<CandidateSandboxEntityModel> GetCandidateSandboxAsync(Guid candidateSandboxId)
        {
            var candidateSandboxes = await _unitOfWork.CandidateSandboxes.FindByConditionAsync(x => x.Id == candidateSandboxId);
            return candidateSandboxes.FirstOrDefault();
        }

        private async Task<bool> HasAnyBlockedFreeTimeAsync(EventDtoModel value)
        {
            var results = await _unitOfWork.Events.FindByConditionAsync(x =>
                x.Type == EventType.FREE      &&
                x.OwnerId == value.OwnerId    &&
                x.StartTime < value.StartTime &&
                value.StartTime < x.EndTime   ||
                x.StartTime < value.EndTime   &&
                value.EndTime < x.EndTime     ||
                (
                    value.StartTime <= x.StartTime &&
                    value.EndTime >= x.EndTime
                ));
            //var interviews = await _unitOfWork.EventMembers.FindByConditionAsync(x => x.MemberId == value.OwnerId);
            return results.Any();
        }

        private async Task<bool> HasAnyBlockedInterviewTimeAsync(EventDtoModel value)
        {
            var results = await _unitOfWork.Events.FindByConditionAsync(x =>
                x.OwnerId == value.OwnerId &&
                x.CandidateSandboxId != null &&
                x.StartTime < value.StartTime &&
                value.StartTime < x.EndTime ||
                x.StartTime < value.EndTime &&
                value.EndTime < x.EndTime ||
                (
                    value.StartTime <= x.StartTime &&
                    value.EndTime >= x.EndTime
                ));
            return results.Any();
        }

        public async Task<bool> DeleteEventAsync(Guid userId, Guid eventId)
        {
            var eventEntities = await _unitOfWork.Events.FindByConditionAsync(x =>
                x.OwnerId == userId &&
                x.Id==eventId &&
                x.Type== EventType.INTERVIEW);
            var eventEntity = eventEntities.FirstOrDefault();
            if (eventEntity != null)
            {
                var googleToken = (await _unitOfWork.GoogleAccessTokens.FindByConditionAsync(x => x.UserId == userId)).FirstOrDefault();
                if (googleToken != null)
                {
                    _googleService.Delete(googleToken, eventEntity.GoogleCalendarEventId);
                }

                _unitOfWork.Events.Delete(eventEntity.Id);
                return true;
            }
            return false;
        }

        public async Task<bool> GetAllGoogleEventsAsync(Guid userId)
        {
            var googleToken = (await _unitOfWork.GoogleAccessTokens.FindByConditionAsync(x => x.UserId == userId)).FirstOrDefault();
            if (googleToken != null)
            {
                var googleEvents = _googleService.GetAll(googleToken);
                if (googleEvents != null)
                {
                    foreach (var googleEvent in googleEvents)
                    {
                        var events = await _unitOfWork.Events.FindByConditionAsync(x=>x.GoogleCalendarEventId==googleEvent.Id);
                        if (events.Any())
                        {
                            continue;
                        }
                        var eventEntity = new EventEntityModel
                        {
                            GoogleCalendarEventId = googleEvent.Id,
                            OwnerId = userId,
                            Summary=googleEvent.Summary,
                            Description=googleEvent.Description,
                            StartTime = DateTime.Parse(googleEvent.Start.DateTime).ToUniversalTime(),
                            EndTime = DateTime.Parse(googleEvent.End.DateTime).ToUniversalTime(),
                            Type = EventType.GOOGLE,
                            CandidateSandboxId=null,
                        };
                        eventEntity = await _unitOfWork.Events.CreateAsync(eventEntity);
                    }
                    await _unitOfWork.SaveAsync();
                    return true;
                }
            }
            return false;
        }
    }
}
