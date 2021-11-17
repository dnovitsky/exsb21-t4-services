using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;

namespace BusinessLogicLayer.Interfaces
{
    public interface IInterviewEventService
    {
        Task<IEnumerable<InterviewEventDtoModel>> GetAllInterviewEventsAsync();
        Task<InterviewEventDtoModel> CreateInterviewEventAsync(InterviewEventDtoModel calendarEvent);
    }
}
