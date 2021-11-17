using System;
using System.Collections.Generic;
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

        public async Task<InterviewEventDtoModel> CreateInterviewEventAsync(InterviewEventDtoModel calendarEvent)
        {
            var entityModel = await unitOfWork.InterviewEvents.CreateAsync(profile.mapToEM(calendarEvent));
            return profile.mapToDto(entityModel);
        }

        
    }
}
