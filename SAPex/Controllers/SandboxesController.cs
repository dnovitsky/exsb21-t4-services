using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Service;
using DbMigrations.Data;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SAPex.Mappers;
using SAPex.Models;
using SAPex.Models.Validators;

namespace SAPex.Controllers
{
    [Route("api/sandboxes")]
    [ApiController]
    public class SandboxesController : ControllerBase
    {
        private readonly ISandboxService _sandboxService;
        private readonly IStackTechnologyService _stackTechnologyService;
        private readonly ILanguageService _languageService;
        private readonly ISandboxLanguageService _sandboxLanguageService;
        private readonly ISandboxStackTechnologyService _sandboxStackTechnologyService;
        private readonly IUserService _userService;
        private readonly IUserSandboxService _userSandboxService;
        private readonly SandboxMapper _mapper;
        private readonly SandboxLanguageMapper _slmapper;
        private readonly SandboxStackTechnologyMapper _sstmapper;
        private readonly InputParametrsMapper _inputParamersMapper;
        private readonly FilterParametrsMapper _filterParametrsMapper;

        public SandboxesController(ISandboxStackTechnologyService sandboxStackTechnologyService,
            ISandboxLanguageService sandboxLanguagesService, ISandboxService sandboxService,
            IStackTechnologyService stackTechnologyService, ILanguageService languageService,
            IUserService userService, IUserSandboxService userSandboxService)
        {
            _sandboxStackTechnologyService = sandboxStackTechnologyService;
            _sandboxLanguageService = sandboxLanguagesService;
            _sandboxService = sandboxService;
            _stackTechnologyService = stackTechnologyService;
            _languageService = languageService;
            _userService = userService;
            _userSandboxService = userSandboxService;
            _mapper = new SandboxMapper();
            _slmapper = new SandboxLanguageMapper();
            _sstmapper = new SandboxStackTechnologyMapper();
            _inputParamersMapper = new InputParametrsMapper();
            _filterParametrsMapper = new FilterParametrsMapper();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            SandboxDtoModel sandboxDtoModel = await _sandboxService.FindSandboxByIdAsync(id);

            if (sandboxDtoModel == null)
            {
                return NotFound();
            }

            IEnumerable<StackTechnologyDtoModel> stackTechnologiesDtoModel = await _stackTechnologyService.GetStackTechnologiesBySandboxIdAsync(id);
            IEnumerable<LanguageDtoModel> languagesDtoModel = await _languageService.GetLanguagesBySandboxIdAsync(id);
            IEnumerable<UserDtoModel> mentorDtoModels = await _userService.GetUsersBySandboxIdConditionFuncRole(s => s.FunctionalRole.Name == "Mentor", id);
            IEnumerable<UserDtoModel> recruiterDtoModels = await _userService.GetUsersBySandboxIdConditionFuncRole(s => s.FunctionalRole.Name == "Recruiter", id);
            IEnumerable<UserDtoModel> interwieverDtoModels = await _userService.GetUsersBySandboxIdConditionFuncRole(s => s.FunctionalRole.Name == "Interviewer", id);

            SandboxViewModel viewModel = _mapper.MapFromDtoToView(sandboxDtoModel, languagesDtoModel, stackTechnologiesDtoModel,
                mentorDtoModels, recruiterDtoModels, interwieverDtoModels);

            return await Task.FromResult(Ok(viewModel));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<SandboxDtoModel> dtoModels = await _sandboxService.GetAllSandboxesAsync();

            IList<SandboxViewModel> viewModels = new List<SandboxViewModel>();

            foreach (var item in dtoModels)
            {
                IEnumerable<StackTechnologyDtoModel> stackTechnologyDtoModels = await _stackTechnologyService.GetStackTechnologiesBySandboxIdAsync(item.Id);
                IEnumerable<LanguageDtoModel> languageDtoModels = await _languageService.GetLanguagesBySandboxIdAsync(item.Id);
                IEnumerable<UserDtoModel> mentorDtoModels = await _userService.GetUsersBySandboxIdConditionFuncRole(s => s.FunctionalRole.Name == "Mentor", item.Id);
                IEnumerable<UserDtoModel> recruiterDtoModels = await _userService.GetUsersBySandboxIdConditionFuncRole(s => s.FunctionalRole.Name == "Recruiter", item.Id);
                IEnumerable<UserDtoModel> interwieverDtoModels = await _userService.GetUsersBySandboxIdConditionFuncRole(s => s.FunctionalRole.Name == "Interviewer", item.Id);

                viewModels.Add(_mapper.MapFromDtoToView(item, languageDtoModels, stackTechnologyDtoModels,
                    mentorDtoModels, recruiterDtoModels, interwieverDtoModels));
            }

            return await Task.FromResult(Ok(viewModels));
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetFilter([FromQuery] InputParametrsViewModel sandboxParametrs, [FromQuery] FilterParametrsViewModel filterParametrs)
        {
            PagedList<SandboxDtoModel> dtoPageListModels = await _sandboxService.GetPagedSandboxesAsync(
                _inputParamersMapper.MapFromViewToDto(sandboxParametrs),
                _filterParametrsMapper.MapFromViewToDto(filterParametrs));

            IList<SandboxViewModel> viewModels = new List<SandboxViewModel>();

            foreach (var item in dtoPageListModels.PageList)
            {
                if (item != null)
                {
                    IEnumerable<StackTechnologyDtoModel> stackTechnologyDtoModels = await _stackTechnologyService.GetStackTechnologiesBySandboxIdAsync(item.Id);
                    IEnumerable<LanguageDtoModel> languageDtoModels = await _languageService.GetLanguagesBySandboxIdAsync(item.Id);
                    IEnumerable<UserDtoModel> mentorDtoModels = await _userService.GetUsersBySandboxIdConditionFuncRole(s => s.FunctionalRole.Name == "Mentor", item.Id);
                    IEnumerable<UserDtoModel> recruiterDtoModels = await _userService.GetUsersBySandboxIdConditionFuncRole(s => s.FunctionalRole.Name == "Recruiter", item.Id);
                    IEnumerable<UserDtoModel> interwieverDtoModels = await _userService.GetUsersBySandboxIdConditionFuncRole(s => s.FunctionalRole.Name == "Interviewer", item.Id);

                    viewModels.Add(_mapper.MapFromDtoToView(item, languageDtoModels, stackTechnologyDtoModels,
                    mentorDtoModels, recruiterDtoModels, interwieverDtoModels));
                }
            }

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(dtoPageListModels.TotalPages));
            return await Task.FromResult(Ok(viewModels));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] SandboxPostViewModel sandboxViewModel)
        {
            Guid sandboxId = await _sandboxService.AddSandboxAsync(_mapper.MapSbFromViewToDto(sandboxViewModel));

            await _sandboxLanguageService.AddSandboxLanguagesListByIdsAsync(sandboxId, sandboxViewModel.LanguageIds);
            await _sandboxStackTechnologyService.AddSandboxStackTechnologyListByIdsAsync(sandboxId, sandboxViewModel.StackTechnologyIds);
            await _userSandboxService.AddUserSandboxListByIdsAsync(sandboxId, sandboxViewModel.MentorIds);
            await _userSandboxService.AddUserSandboxListByIdsAsync(sandboxId, sandboxViewModel.InterviewersIds);
            await _userSandboxService.AddUserSandboxListByIdsAsync(sandboxId, sandboxViewModel.RecruiterIds);

            return await Task.FromResult(Ok(sandboxId));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] SandboxPutViewModel sandboxViewModel)
        {
            sandboxViewModel.Id = id;

            await _sandboxLanguageService.UpdateSandboxLanguagesListByIdsAsync(id, sandboxViewModel.LanguageIds);
            await _sandboxStackTechnologyService.UpdateSandboxStackTechnologiesListByIdsAsync(id, sandboxViewModel.StackTechnologyIds);

            await _userSandboxService.DeleteUserSandboxListByIdsAsync(id);

            await _userSandboxService.AddUserSandboxListByIdsAsync(id, sandboxViewModel.MentorIds);
            await _userSandboxService.AddUserSandboxListByIdsAsync(id, sandboxViewModel.InterviewersIds);
            await _userSandboxService.AddUserSandboxListByIdsAsync(id, sandboxViewModel.RecruiterIds);

            _sandboxService.UpdateSandbox(_mapper.MapSbFromViewToDto(sandboxViewModel));

            return await Task.FromResult(Ok());
        }
    }
}
