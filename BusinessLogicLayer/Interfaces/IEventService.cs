using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels.DataTypes;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventDtoModel>> GetAllAsync();
        Task<EventDtoModel> GetEventByIdAsync(Guid id);
        Task<IEnumerable<EventDtoModel>> GetAllFilterAsync(DateTime start, DateTime end, EventType type);
        Task<IEnumerable<EventDtoModel>> GetAllUserFilterAsync(Guid userId, DateTime start, DateTime end, EventType type);
        Task<IEnumerable<EventDtoModel>> GetAllByUserIdAsync(Guid userId);

        Task<EventDtoModel> CreateFreeEventAsync(EventDtoModel eventDto);
        Task<EventDtoModel> CreateEventAsync(EventDtoModel eventDto);

        Task<EventDtoModel> UpdateEventAsync(EventDtoModel eventDto);

        Task<bool> DeleteEventAsync(string email, Guid eventId);

        Task<bool> GetAllGoogleEventsAsync(Guid userId);
        
    }
}
