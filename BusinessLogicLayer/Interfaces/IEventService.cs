using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces.Base;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEventService : IService<EventDtoModel>
    {
        Task<EventDtoModel> CreateInterviewAsync(EventDtoModel eventDto);
        Task<IEnumerable<EventDtoModel>> GetAllAsync(DateTime start, DateTime end, EventType type = EventType.ALL);
    }
}
