using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
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
        public async Task<IEnumerable<InterviewEventViewModel>> GetAsync()
        {
            var events = await _eventService.GetAllAsync();
            return _mapper.Map<IEnumerable<InterviewEventViewModel>>(events);
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<InterviewEventViewModel>> GetAsync(Guid eventId)
        {
            var event_ = await _eventService.GetEventByIdAsync(eventId);
            if (event_ != null)
            {
                return Ok(_mapper.Map<InterviewEventViewModel>(event_));
            }

            return NotFound();
        }

        [HttpGet("/user/{userId}")]
        public async Task<IEnumerable<InterviewEventViewModel>> GetUserEventsAsync(Guid userId)
        {
            var events = await _eventService.GetAllByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<InterviewEventViewModel>>(events);
        }

        [HttpGet("{start}/{end}")]
        public async Task<IEnumerable<InterviewEventViewModel>> GetAsync([FromRoute] DateTime start, [FromRoute] DateTime end)
        {
            var events = await _eventService.GetAllByRangeAsync(start, end);
            return _mapper.Map<IEnumerable<InterviewEventViewModel>>(events);
        }

        [HttpPost("free-time")]

        // [Authorize(Roles = "Interviewer")]
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

        [HttpPost("interview-time")]

        // [Authorize(Roles = "Recruiter")]
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

        [HttpDelete("interview-time/{userId}/{eventId}")]
        public async Task<ActionResult> DeleteAsync(Guid userId, Guid eventId)
        {
            var result = await _eventService.DeleteEventAsync(userId, eventId);
            if (result)
            {
                return Ok();
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
