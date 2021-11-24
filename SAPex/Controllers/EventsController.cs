using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using DbMigrations.EntityModels.DataTypes;
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

        [HttpGet("{start}/{end}/{type}")]
        public async Task<IEnumerable<InterviewEventViewModel>> GetAsync([FromRoute] DateTime start, [FromRoute] DateTime end, [FromRoute] EventType type = EventType.FREE)
        {
            var events = await _eventService.GetAllAsync(start, end, type);
            return _mapper.Map<IEnumerable<InterviewEventViewModel>>(events);
        }

        [HttpPost("free-time")]

        // [Authorize(Roles = "Interviewer")]
        public async Task<ActionResult<EventViewModel>> PostAsync([FromBody] CreateEventViewModel eventView)
        {
            EventDtoModel eventDto = _mapper.Map<EventDtoModel>(eventView);
            eventDto = await _eventService.CreateAsync(eventDto);
            if (eventDto != null)
            {
                return _mapper.Map<EventViewModel>(eventDto);
            }

            return BadRequest();
        }

        [HttpPost("interview-time")]

        // [Authorize(Roles = "Recruiter")]
        public async Task<ActionResult<InterviewEventViewModel>> PostAsync([FromBody] CreateInterviewEventViewModel eventView)
        {
            EventDtoModel eventDto = _mapper.Map<EventDtoModel>(eventView);
            eventDto = await _eventService.CreateInterviewAsync(eventDto);
            return _mapper.Map<InterviewEventViewModel>(eventDto);
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
        public async Task<ActionResult> GetAsync(Guid userId)
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
