using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventDtoModel>> GetAllAsync();
        Task<EventDtoModel> GetEventByIdAsync(Guid id);
        Task<IEnumerable<EventDtoModel>> GetAllByRangeAsync(DateTime start, DateTime end);

        Task<IEnumerable<EventDtoModel>> GetAllByUserIdAsync(Guid userId);

        Task<EventDtoModel> CreateFreeEventAsync(EventDtoModel eventDto);
        Task<EventDtoModel> CreateEventAsync(EventDtoModel eventDto);

        Task<EventDtoModel> UpdateEventAsync(EventDtoModel eventDto);

        Task<bool> DeleteEventAsync(Guid userId, Guid eventId);

        Task<bool> GetAllGoogleEventsAsync(Guid userId);
        
    }
}
