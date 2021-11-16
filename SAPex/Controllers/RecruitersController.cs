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
    [Route("api/recruiters")]
    [ApiController]
    public class RecruitersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly RecruiterMapper _mapper = new RecruiterMapper();

        public RecruitersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInterviewers()
        {
            IEnumerable<UserDtoModel> recruitersDto = await _userService.FindAllByConditionAsync(s => s.FunctionalRole.Name == "Recruiter");
            IList<RecruiterViewModel> recruiterVM = new List<RecruiterViewModel>();

            foreach (var recruiter in recruitersDto)
            {
                recruiterVM.Add(_mapper.MapRecruiterFromDtoToView(recruiter));
            }

            return await Task.FromResult(Ok(recruiterVM));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInterviewerById(Guid id)
        {
            UserDtoModel recruiterDto = await _userService.FindByIdConditionAsync(s => s.FunctionalRole.Name == "Recruiter" && s.UserId == id);

            if (recruiterDto == null)
            {
                return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(_mapper.MapRecruiterFromDtoToView(recruiterDto)));
        }
    }
}
