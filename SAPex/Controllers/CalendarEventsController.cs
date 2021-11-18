using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAPex.Mappers;
using SAPex.Models;

namespace SAPex.Controllers
{
    [Route("/api/calendarevents")]
    [ApiController]

    // [Authorize]
    public class CalendarEventsController : ControllerBase
    {
        private readonly ICalendarEventService _calendarEventService;

        private readonly CalendarEventMapper _mapper = new ();
        private readonly CreateCalendarEventMapper _mapperCreate = new ();

        public CalendarEventsController(ICalendarEventService calendarEventService)
        {
            _calendarEventService = calendarEventService;
        }

        [HttpGet]
        public async Task<IEnumerable<CalendarEventViewModel>> GetAsync()
        {
            IEnumerable<CalendarEventDtoModel> calendarEvents = await _calendarEventService.GetAllCalendarEventsAsync();
            return _mapper.ListDtoToListView(calendarEvents);
        }

        [HttpPost]
        [Authorize(Roles = "Interviewer")]
        public async Task<ActionResult<IEnumerable<CalendarEventViewModel>>> PostAsync([FromBody] IList<CreateCalendarEventViewModel> events)
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var email = identity.FindFirst(ClaimTypes.Email).Value;
                var dtos = _mapperCreate.ListViewToListDto(events);
                var calendarEvents = await _calendarEventService.CreateAllCalendarEventsAsync(dtos, email);
                return Ok(_mapper.ListDtoToListView(calendarEvents));
            }

            return NotFound();
        }

        [HttpGet("{dateTime}")]
        [Authorize(Roles = "Recruiter")]
        public async Task<IEnumerable<CalendarEventViewModel>> GetAsync([FromRoute] DateTime dateTime)
        {
            IEnumerable<CalendarEventDtoModel> calendarEvents = await _calendarEventService.GetCalendarEventsByDayAsync(dateTime);
            return _mapper.ListDtoToListView(calendarEvents);
        }
    }
}
