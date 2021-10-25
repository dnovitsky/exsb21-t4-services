
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SAPex.Models;
using SAPex.Services.Google.IGoogleSevices;

namespace SAPex.Controllers
{

    [Route("api/google/calendars")]
    [ApiController]
    public class GoogleCalendarController : ControllerBase
    {
        private IGoogleCalendarService calendarService;

        public GoogleCalendarController(IGoogleCalendarService calendarService)
        {
            this.calendarService = calendarService;
        }

        [HttpGet("{email}")]
        public ActionResult<IEnumerable<GoogleCalendar>> Get(string email)
        {
            List<GoogleCalendar> calendars = calendarService.Get(email);
            if (calendars != null) {
                return Ok(calendars);
            }
            return BadRequest();
        }

        [HttpGet("{email}/{id}")]
        public ActionResult<GoogleCalendar> Get(string email, string id)
        {

            GoogleCalendar calendar = calendarService.Get(email, id);
            if (calendar != null)
            {
                return Ok(calendar);
            }
            return BadRequest();

        }

        [HttpPost("{email}")]
        public ActionResult Post(string email,[FromBody] GoogleCalendar calendar)
        {
            bool added = calendarService.Add(email, calendar);
            if (added)
            {
                return Ok();
            }
            return BadRequest();

        }

        [HttpDelete("{email}/{id}")]
        public ActionResult Delete(string email,string id)
        {
            bool deleted = calendarService.Delete(email, id);
            if (deleted)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPatch("{email}")]
        public ActionResult Patch(string email, [FromBody] GoogleCalendar calendar)
        {
            bool updated = calendarService.Update(email, calendar);
            if (updated)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
