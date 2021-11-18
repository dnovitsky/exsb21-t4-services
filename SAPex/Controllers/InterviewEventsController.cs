using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SAPex.Mappers;
using SAPex.Models;

namespace SAPex.Controllers
{
    [Route("/api/interviewevents")]
    [ApiController]
    public class InterviewEventsController : ControllerBase
    {
        protected readonly IInterviewEventService _eventService;

        private readonly InterviewEventMapper _mapper = new ();
        private readonly CreateInterviewEventMapper _mapperCreate = new ();

        public InterviewEventsController(IInterviewEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IEnumerable<InterviewEventViewModel>> GetAsync()
        {
            var events = await _eventService.GetAllInterviewEventsAsync();
            return _mapper.ListDtoToListView(events);
        }

        [HttpPost]
        public async Task<InterviewEventViewModel> PostAsync([FromBody] CreateInterviewEventViewModel interviewView)
        {
            var interviewDto = await _eventService.CreateInterviewEventAsync(_mapperCreate.ViewToDto(interviewView));
            return _mapper.DtoToView(interviewDto);
        }
    }
}
