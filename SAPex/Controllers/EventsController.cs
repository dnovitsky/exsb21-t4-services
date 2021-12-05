using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using DbMigrations.EntityModels.DataTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAPex.Models.EventModels;

namespace SAPex.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventsController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<InterviewEventViewModel>> GetAllAsync()
        {
            var events = await _eventService.GetAllAsync();
            return _mapper.Map<IEnumerable<InterviewEventViewModel>>(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InterviewEventViewModel>> GetAsync(Guid id)
        {
            var event_ = await _eventService.GetEventByIdAsync(id);
            if (event_ != null)
            {
                return Ok(_mapper.Map<InterviewEventViewModel>(event_));
            }

            return NotFound();
        }

        [HttpGet("filter")]
        public async Task<IEnumerable<InterviewEventViewModel>> GetFilterAsync([FromQuery] DateTime start, [FromQuery] DateTime end, [FromQuery] EventType type)
        {
            var events = await _eventService.GetAllFilterAsync(start, end, type);
            return _mapper.Map<IEnumerable<InterviewEventViewModel>>(events);
        }

        [HttpPost("free-time")]
        [Authorize(Roles = "Interviewer")]
        public async Task<ActionResult<EventViewModel>> PostAsync([FromBody] CreateEventViewModel eventView)
        {
            EventDtoModel eventDto = _mapper.Map<EventDtoModel>(eventView);
            eventDto = await _eventService.CreateFreeEventAsync(eventDto);
            if (eventDto != null)
            {
                return Ok(_mapper.Map<EventViewModel>(eventDto));
            }

            return BadRequest();
        }

        [HttpPut("free-time/{id}")]
        [Authorize(Roles = "Interviewer")]
        public async Task<ActionResult<EventViewModel>> PutAsync([FromRoute]Guid id, [FromBody] CreateEventViewModel eventView)
        {
            EventDtoModel eventDto = _mapper.Map<EventDtoModel>(eventView);
            eventDto = await _eventService.UpdateEventAsync(id, eventDto);
            if (eventDto != null)
            {
                return Ok(_mapper.Map<EventViewModel>(eventDto));
            }

            return BadRequest();
        }

        [HttpPost("interview-time")]
        [Authorize(Roles = "Recruiter")]
        public async Task<ActionResult<InterviewEventViewModel>> PostAsync([FromBody] CreateInterviewEventViewModel eventView)
        {
            EventDtoModel eventDto = _mapper.Map<EventDtoModel>(eventView);
            eventDto = await _eventService.CreateEventAsync(eventDto);
            if (eventDto != null)
            {
                return Ok(_mapper.Map<InterviewEventViewModel>(eventDto));
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var email = identity.FindFirst(ClaimTypes.Email).Value;
                var result = await _eventService.DeleteEventAsync(email, id);
                if (result)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }

        [HttpGet("google/{userId}")]
        public async Task<ActionResult> GetSyncGoogleCalendarAsync(Guid userId)
        {
            var result = await _eventService.GetAllGoogleEventsAsync(userId);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
