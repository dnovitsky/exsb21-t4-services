using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces.Base;
using DbMigrations.EntityModels.DataTypes;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEventService : IService<EventDtoModel>
    {
        Task<EventDtoModel> CreateInterviewAsync(EventDtoModel eventDto);
        Task<IEnumerable<EventDtoModel>> GetAllAsync(DateTime start, DateTime end, EventType type = EventType.FREE);
        Task<bool> DeleteEventAsync(Guid userId, Guid eventId);
        Task<bool> GetAllGoogleEventsAsync(Guid userId);
    }
}
