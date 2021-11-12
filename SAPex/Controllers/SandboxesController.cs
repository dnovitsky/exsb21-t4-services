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
using PagedList;
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
        private readonly ISandboxLanguagesService _sandboxLanguageService;
        private readonly ISandboxStackTechnologyService _sandboxStackTechnologyService;
        private readonly SandboxMapper _mapper = new SandboxMapper();
        private readonly SandboxLanguageMapper _slmapper = new SandboxLanguageMapper();
        private readonly SandboxStackTechnologyMapper _sstmapper = new SandboxStackTechnologyMapper();

        public SandboxesController(ISandboxStackTechnologyService sandboxStackTechnologyService, ISandboxLanguagesService sandboxLanguagesService, ISandboxService sandboxService,
            IStackTechnologyService stackTechnologyService, ILanguageService languageService)
        {
            _sandboxStackTechnologyService = sandboxStackTechnologyService;
            _sandboxLanguageService = sandboxLanguagesService;
            _sandboxService = sandboxService;
            _stackTechnologyService = stackTechnologyService;
            _languageService = languageService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            SandboxDtoModel sandboxDtoModel = await _sandboxService.FindSandboxByIdAsync(id); // on what level goes null check? it should go directly to db?
            IEnumerable<StackTechnologyDtoModel> stackTechnologyDtoModel = await _stackTechnologyService.GetStackTechnologiesBySandboxIdAsync(id);
            IEnumerable<LanguageDtoModel> languageDtoModel = await _languageService.GetLanguagesBySandboxIdAsync(id);

            if (sandboxDtoModel == null)
            {
                return await Task.FromResult(NotFound());
            }

            SandboxViewModel viewModel = _mapper.MapSbStackLgFromDtoToView(sandboxDtoModel, languageDtoModel, stackTechnologyDtoModel);

            return await Task.FromResult(Ok(viewModel)); // convert to json?
        }

        [HttpGet]
        public async Task<IActionResult> GetByPage(int pageNumber = 1, int pageSize = 5, string sortOrder = "name", string searchString = "")
        {
            IEnumerable<SandboxDtoModel> dtoModels = await _sandboxService.GetAllSandboxesAsync(); // on what level goes null check? it should go directly to db?

            // IEnumerable<IEnumerable<StackTechnologyDtoModel>> stackTechnologyDtoModels =
            // IEnumerable<LanguageDtoModel> languageDtoModel = await _languageService.GetLanguagesBySandboxIdAsync(id);

            if (dtoModels == null)
            {
                return await Task.FromResult(NotFound()); // return null
            }

            IEnumerable<SandboxViewModel> viewModels = _mapper.MapListSbFromDtoToView(dtoModels);

            if (!string.IsNullOrEmpty(searchString))
            {
                viewModels = viewModels.Where(s => s.Description.Contains(searchString) || s.Name.Contains(searchString));
            }

            switch (sortOrder.ToLower())
            {
                case "name":
                    viewModels = viewModels.OrderBy(s => s.Name).ToList();
                    break;
                case "maxcandidates":
                    viewModels = viewModels.OrderBy(s => s.MaxCandidates).ToList();
                    break;
                case "createdate":
                    viewModels = viewModels.OrderBy(s => s.CreateDate).ToList();
                    break;
                case "startdate":
                    viewModels = viewModels.OrderBy(s => s.StartDate).ToList();
                    break;
                case "description":
                    viewModels = viewModels.OrderBy(s => s.Description).ToList();
                    break;
                case "enddate":
                    viewModels = viewModels.OrderBy(s => s.EndDate).ToList();
                    break;
                case "startregistration":
                    viewModels = viewModels.OrderBy(s => s.StartRegistration).ToList();
                    break;
                case "endregistration":
                    viewModels = viewModels
                        .OrderBy(s => s.EndRegistration)
                        .Skip(pageNumber - 1)
                        .Take(pageSize)
                        .ToList();
                    break;

                default:
                    break;
            }

            return await Task.FromResult(Ok(viewModels.ToPagedList(pageNumber, pageSize)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SandboxViewModel requestData)
        {
            ValidationResult validationResult = new SandboxValidator().Validate(requestData); // ? check if requestData already exists, do not push if true, on what fields

            // check this

            if (!validationResult.IsValid)
            {
                return await Task.FromResult(BadRequest());
            }

            IEnumerable<StackTechnologyViewModel> stackTechnologyVM = requestData.StackTechnologies;
            requestData.StackTechnologies = null;
            IEnumerable<LanguageViewModel> languagesVM = requestData.Languages;
            requestData.Languages = null;

            Guid sandId = await _sandboxService.AddSandboxAsync(_mapper.MapSbFromViewToDto(requestData));

            IList<SandboxLanguageViewModel> sandboxLanguageVM = new List<SandboxLanguageViewModel>();

            foreach (var elem in languagesVM)
            {
                SandboxLanguageViewModel example = new SandboxLanguageViewModel { SandboxId = sandId, LanguageId = elem.Id };
                sandboxLanguageVM.Add(example);
            }

            IEnumerable<SandboxLanguageDtoModel> sandboxLanguagesDto = _slmapper.MapListSBLFromVMToDto(sandboxLanguageVM);

            foreach (var elem in sandboxLanguagesDto)
            {
                await _sandboxLanguageService.AddSandboxLanguageAsync(elem);
            }

            IList<SandboxStackTechnologyViewModel> sandboxStackTechnologiesVM = new List<SandboxStackTechnologyViewModel>();

            foreach (var elem in sandboxStackTechnologiesVM)
            {
                SandboxStackTechnologyViewModel example = new SandboxStackTechnologyViewModel { SandboxId = sandId, StackTechnologyId = elem.Id };
                sandboxStackTechnologiesVM.Add(example);
            }

            IEnumerable<SandboxStackTechnologyDtoModel> sandboxStackTechnologiesDto = _sstmapper.MapListSBSTFromVMToDto(sandboxStackTechnologiesVM);

            foreach (var elem in sandboxStackTechnologiesDto)
            {
                await _sandboxStackTechnologyService.AddSandboxStackTechnologyAsync(elem);
            }

            return await Task.FromResult(Ok()); // need message?
        }

        // [HttpPut]
        // public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] SandboxViewModel requestData) // ? id
        // {
        //    ValidationResult validationResult = new SandboxValidator().Validate(requestData); // check if already exists update
        //    if (!validationResult.IsValid)
        //    {
        //        return await Task.FromResult(BadRequest());
        //    }
        //    _service.UpdateSandbox(_mapper.MapSbFromViewToDto(requestData)); // where goes check on exist
        //    return await Task.FromResult(Ok());
        // }
    }
}
