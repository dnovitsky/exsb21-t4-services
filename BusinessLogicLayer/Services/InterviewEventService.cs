using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Services
{
    public class InterviewEventService : IInterviewEventService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly InterviewEventProfile profile = new();

        public InterviewEventService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<InterviewEventDtoModel>> GetAllInterviewEventsAsync()
        {
            IEnumerable<InterviewEventEntityModel> interviewEvents = await unitOfWork.InterviewEvents.GetAllAsync();
            return profile.mapListToDto(interviewEvents);
        }

        public async Task<InterviewEventDtoModel> CreateInterviewEventAsync(InterviewEventDtoModel interviewEvent)
        {
            var calendarCheck = await unitOfWork.CalendarEvents.FindByIdAsync(interviewEvent.CalendarEventId);

            if (calendarCheck.StartTime <= interviewEvent.StartTime && interviewEvent.EndTime <= calendarCheck.EndTime)
            {
                var check = await unitOfWork.InterviewEvents.FindByConditionAsync(
                x => x.CalendarEventId == interviewEvent.CalendarEventId && (
                (x.StartTime < interviewEvent.StartTime && interviewEvent.StartTime < x.EndTime) ||
                (x.StartTime < interviewEvent.EndTime && interviewEvent.EndTime < x.EndTime)));

                if (!check.Any())
                {
                    var entityModel = await unitOfWork.InterviewEvents.CreateAsync(profile.mapToEM(interviewEvent));
                    return profile.mapToDto(entityModel);
                }
            }
            return null;

            
        }

        
    }
}
