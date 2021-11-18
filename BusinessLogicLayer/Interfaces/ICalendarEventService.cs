using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICalendarEventService
    {
        Task<IEnumerable<CalendarEventDtoModel>> GetAllCalendarEventsAsync();
        Task<CalendarEventDtoModel> CreateCalendarEventAsync(CalendarEventDtoModel calendarEvent);
        Task<IEnumerable<CalendarEventDtoModel>> CreateAllCalendarEventsAsync(IEnumerable<CalendarEventDtoModel> calendarEvents, string email);
        Task<IEnumerable<CalendarEventDtoModel>> GetCalendarEventsByDayAsync(DateTime dateTime);
        Task UpdateAsync(CalendarEventDtoModel calendarEvent);
    }
}
