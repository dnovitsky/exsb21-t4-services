using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SAPex.Controllers.Mapping;
using SAPex.Mappers;
using SAPex.Models;

namespace SAPex.Controllers
{
    [Route("api/recruiters")]
    [ApiController]
    public class RecruitersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserCandidateSandboxService _userCandidateSandboxService;
        private readonly ICandidateService _candidateService;
        private readonly RecruiterMapper _mapper = new RecruiterMapper();
        private readonly CandidateMapper _candidateMapper = new CandidateMapper();

        public RecruitersController(IUserService userService,
            IUserCandidateSandboxService userCandidateSandboxService,
            ICandidateService candidateService)
        {
            _userService = userService;
            _userCandidateSandboxService = userCandidateSandboxService;
            _candidateService = candidateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecruiters()
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
        public async Task<IActionResult> GetRecruiterById(Guid id)
        {
            UserDtoModel recruiterDto = await _userService.FindByIdConditionAsync(s => s.FunctionalRole.Name == "Recruiter" && s.UserId == id);

            if (recruiterDto == null)
            {
                return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(_mapper.MapRecruiterFromDtoToView(recruiterDto)));
        }

        [HttpGet("{id}/candidates")]
        public async Task<IActionResult> GetCandidatesByRecruiterId(Guid id)
        {
           IEnumerable<CandidateDtoModel> candidatesDto = await _candidateService.GetCandidatesByUserIdAsync(id);

           return await Task.FromResult(Ok(_candidateMapper.MapCandidateDtoToVM(candidatesDto)));
        }

        [HttpPost("{id}/candidates")]
        public async Task<IActionResult> AssignCandidatesToRecruiter([FromRoute] Guid id, [FromBody] IEnumerable<Guid> candidateSandboxIds)
        {
            await _userCandidateSandboxService.AddUserCandidateSandboxesAsync(id, candidateSandboxIds);

            return await Task.FromResult(Ok());
        }
    }
}
