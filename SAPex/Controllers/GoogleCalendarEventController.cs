
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SAPex.Models;
using SAPex.Services.Google.IGoogleSevices;

namespace SAPex.Controllers
{
    [Route("api/google/events")]
    [ApiController]
    public class GoogleCalendarEventController : ControllerBase
    {
        private IGoogleCalendarEventService eventService;

        public GoogleCalendarEventController(IGoogleCalendarEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet("{email}")]
        public ActionResult<IEnumerable<GoogleCalendarEvent>> Get([FromRoute] string email)
        {
            List<GoogleCalendarEvent> events = eventService.Get(email);
            if (events != null)
            {
                return Ok(events);
            }
            return BadRequest();
        }

        [HttpGet("{email}/{id}")]
        public ActionResult<GoogleCalendarEvent> Get([FromRoute] string email, [FromRoute] string id)
        {
            GoogleCalendarEvent _event = eventService.Get(email,id);
            if (_event != null)
            {
                return Ok(_event);
            }
            return BadRequest();


        }

        [HttpPost("{email}")]
        public ActionResult Post([FromRoute] string email,[FromBody] GoogleCalendarEvent _event)
        {
            bool added = eventService.Add(email, _event);
            if (added) {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{email}/{id}")]
        public ActionResult<GoogleCalendarEvent> Delete([FromRoute] string email, [FromRoute] string id)
        {
            bool deleted = eventService.Delete(email, id);
            if (deleted)
            {
                return Ok();
            }
            return BadRequest();


        }

        [HttpPatch("{email}")]
        public ActionResult Patch([FromRoute] string email, [FromBody] GoogleCalendarEvent _event)
        {
            bool updated = eventService.Update(email, _event);
            if (updated)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
