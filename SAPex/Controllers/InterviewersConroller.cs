using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SAPex.Mappers;
using SAPex.Models;

namespace SAPex.Controllers
{
    [Route("api/interviewers")]
    [ApiController]
    public class InterviewersConroller : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly InterviewerMapper _mapper = new InterviewerMapper();

        public InterviewersConroller(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInterviewers()
        {
            IEnumerable<UserDtoModel> interviewersDto = await _userService.FindInterviewersAsync(s => s.FunctionalRole.Name == "Interviewer");
            IList<InterviewerViewModel> interviewerVM = new List<InterviewerViewModel>();

            foreach (var interviewer in interviewersDto)
            {
                interviewerVM.Add(_mapper.MapInterviewerFromDtoToView(interviewer));
            }

            return await Task.FromResult(Ok(interviewerVM));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInterviewerById(Guid id)
        {
            UserDtoModel interviewerDto = await _userService.FindInterviewerByIdAsync(s => s.FunctionalRole.Name == "Interviewer" && s.UserId == id);

            if (interviewerDto == null)
            {
                return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(_mapper.MapInterviewerFromDtoToView(interviewerDto)));
        }
    }
}
