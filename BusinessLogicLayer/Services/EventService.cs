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

namespace BusinessLogicLayer.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EventService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
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

        public async Task<IEnumerable<EventDtoModel>> GetAllAsync(DateTime start, DateTime end, EventType type = EventType.ALL)
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
            if (await HasAnyBlockedFreeTimeAsync(value) || !await HasAnyUserAsync(value))
            {
                return null;
            }
            EventEntityModel eventEntity = _mapper.Map<EventEntityModel>(value);
            eventEntity.CandidateSandboxId = null;
            eventEntity = await _unitOfWork.Events.CreateAsync(eventEntity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<EventDtoModel>(eventEntity);
        }

        public async Task<EventDtoModel> CreateInterviewAsync(EventDtoModel value)
        {
            if (await HasAnyBlockedInterviewTimeAsync(value) || !await HasAnyUserAsync(value) || !await HasAnyCandidateSandboxAsync(value))
            {
                return null;
            }
            EventEntityModel eventEntity = _mapper.Map<EventEntityModel>(value);
            eventEntity = await _unitOfWork.Events.CreateAsync(eventEntity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<EventDtoModel>(eventEntity);
        }

        public Task UpdateAsync(EventDtoModel value)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> HasAnyUserAsync(EventDtoModel value)
        {
            var users = await _unitOfWork.Users.FindByConditionAsync(x => x.Id == value.InterviewerId);
            return users.Any();
        }

        private async Task<bool> HasAnyCandidateSandboxAsync(EventDtoModel value)
        {
            var users = await _unitOfWork.CandidateSandboxes.FindByConditionAsync(x => x.Id == value.CandidateSandboxId);
            return users.Any();
        }

        private async Task<bool> HasAnyBlockedFreeTimeAsync(EventDtoModel value)
        {
            var results = await _unitOfWork.Events.FindByConditionAsync(x =>
                x.InterviewerId == value.InterviewerId &&
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

        private async Task<bool> HasAnyBlockedInterviewTimeAsync(EventDtoModel value)
        {
            var results = await _unitOfWork.Events.FindByConditionAsync(x =>
                x.InterviewerId == value.InterviewerId &&
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

        


        //17 25
        //17<x&x<25|17<y&y<25
        //x<=17&y=>25
        //x y

    }
}
