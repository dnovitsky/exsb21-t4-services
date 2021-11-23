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
            if (await HasAnyBlockedFreeTimeAsync(value) || (await HasAnyUserAsync(value.OwnerId)) != null)
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
            if (await HasAnyBlockedInterviewTimeAsync(value) || (await HasAnyUserAsync(value.OwnerId)) == null )//|| !await HasAnyCandidateSandboxAsync(value))
            {
                return null;
            }
            var members = new List<UserEntityModel>();
            foreach(var member in value.Members)
            {
                var user = await HasAnyUserAsync(member);
                if (user == null)
                {
                    return null;
                }
                members.Add(user);
            }
            var eventEntity = _mapper.Map<EventEntityModel>(value);

            eventEntity = await _unitOfWork.Events.CreateAsync(eventEntity);
            
            
            var start = new DateTimeGoogleModel();
            start.DateTime = value.StartTime.ToString();
            start.TimeZone = "UTC";
            var end = new DateTimeGoogleModel();
            end.DateTime = value.EndTime.ToString();
            end.TimeZone = "UTC";
            var attendees = new List<AttendeeGoogleModel>();
            foreach (var member in members)
            {
                var attendee = new AttendeeGoogleModel();
                var eventMember = new EventMemberEntityModel
                {
                    Name = $"{member.Name} {member.Surname}",
                    EventId = eventEntity.Id,
                    MemberId = member.Id,
                    MemberEmail = member.Email,
                };
                attendee.DisplayName = eventMember.Name;
                attendee.Email = eventMember.MemberEmail;
                attendee.Organizer = false;
                attendee.Self = false;
                attendees.Add(attendee);
                await _unitOfWork.EventMembers.CreateAsync(eventMember);
            }
            var owner = await _unitOfWork.Users.FindByIdAsync(value.OwnerId);
            attendees.Add(new AttendeeGoogleModel
            {
                DisplayName = $"{owner.Name} {owner.Surname}",
                Email=owner.Email,
                Organizer=true,
                Self=true
            }) ;
            var eventGoogle = new EventGoogleModel()
            {
                Summary = value.Summary,
                Description = value.Description,
                Start=start,
                End=end,
                Attendees=attendees
            };
            var tokens=(await _unitOfWork.GoogleAccessTokens.FindByConditionAsync(x=> x.UserId==owner.Id)).FirstOrDefault();
            eventGoogle =_googleService.Add(tokens,eventGoogle);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<EventDtoModel>(eventEntity);
        }

        public Task UpdateAsync(EventDtoModel value)
        {
            throw new NotImplementedException();
        }

        private async Task<UserEntityModel> HasAnyUserAsync(Guid userId)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(userId);
            return user;
        }

        private async Task<bool> HasAnyCandidateSandboxAsync(EventDtoModel value)
        {
            var users = await _unitOfWork.CandidateSandboxes.FindByConditionAsync(x => x.Id == value.CandidateSandboxId);
            return users.Any();
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
    }
}
