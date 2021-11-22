using System;
using System.Collections;
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
    public class CalendarEventService : ICalendarEventService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CalendarEventProfile profile = new();

        public CalendarEventService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CalendarEventDtoModel>> GetAllCalendarEventsAsync()
        {
            IEnumerable<CalendarEventEntityModel> calendarEvents = await unitOfWork.CalendarEvents.GetAllAsync();
            return profile.mapListToDto(calendarEvents);
        }

        public async Task<CalendarEventDtoModel> CreateCalendarEventAsync(CalendarEventDtoModel calendarEvent)
        {
            var check = await unitOfWork.CalendarEvents.FindByConditionAsync(
                x => x.InterviewerId == calendarEvent.InterviewerId && (
                (x.StartTime < calendarEvent.StartTime && calendarEvent.StartTime < x.EndTime) ||
                (x.StartTime < calendarEvent.EndTime && calendarEvent.EndTime < x.EndTime)));
            if (!check.Any())
            {
                var calendar = await unitOfWork.CalendarEvents.CreateAsync(profile.mapToEM(calendarEvent));
                await unitOfWork.SaveAsync();
                return profile.mapToDto(calendar);
            }

            return null;
            
        }


        public async Task<IEnumerable<CalendarEventDtoModel>> CreateAllCalendarEventsAsync(IEnumerable<CalendarEventDtoModel> calendarEvents,string email)
        {
            IList<CalendarEventDtoModel> calendars = new List<CalendarEventDtoModel>();
            var users = await unitOfWork.Users.FindByConditionAsync(x => x.Email == email);
            var user = users.FirstOrDefault();

            foreach (var calendarEvent in calendarEvents)
            {
                calendarEvent.InterviewerId = user.Id;
                var calendar = await CreateCalendarEventAsync(calendarEvent);
                calendars.Add(calendar);
            }
            return calendars;
        }

        public async Task<IEnumerable<CalendarEventDtoModel>> GetCalendarEventsByDayAsync(DateTime startOfDay)
        {
            DateTime endOfDay = startOfDay.AddHours(24);
            IEnumerable<CalendarEventEntityModel> calendarEvents = await unitOfWork.CalendarEvents.FindByConditionAsync(x => x.StartTime > startOfDay && x.StartTime < endOfDay);
            return profile.mapListToDto(calendarEvents);
        }

        public async Task UpdateAsync(CalendarEventDtoModel calendarEvent)
        {
            unitOfWork.CalendarEvents.Update(profile.mapToEM(calendarEvent));
            await unitOfWork.SaveAsync();
        }
    }
}
