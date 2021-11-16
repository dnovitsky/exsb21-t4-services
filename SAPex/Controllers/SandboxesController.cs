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
        private readonly SandboxMapper _mapper;
        private readonly SandboxLanguageMapper _slmapper;
        private readonly SandboxStackTechnologyMapper _sstmapper;
        private readonly InputParametrsMapper _inputParamersMapper;
        private readonly FilterParametrsMapper _filterParametrsMapper;

        public SandboxesController(ISandboxStackTechnologyService sandboxStackTechnologyService,
            ISandboxLanguageService sandboxLanguagesService, ISandboxService sandboxService,
            IStackTechnologyService stackTechnologyService, ILanguageService languageService)
        {
            _sandboxStackTechnologyService = sandboxStackTechnologyService;
            _sandboxLanguageService = sandboxLanguagesService;
            _sandboxService = sandboxService;
            _stackTechnologyService = stackTechnologyService;
            _languageService = languageService;
            _mapper = new SandboxMapper();
            _slmapper = new SandboxLanguageMapper();
            _sstmapper = new SandboxStackTechnologyMapper();
            _inputParamersMapper = new InputParametrsMapper();
            _filterParametrsMapper = new FilterParametrsMapper();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            SandboxDtoModel sandboxDtoModel = await _sandboxService.FindSandboxByIdAsync(id); // on what level goes null check? it should go directly to db?
            IEnumerable<StackTechnologyDtoModel> stackTechnologiesDtoModel = await _stackTechnologyService.GetStackTechnologiesBySandboxIdAsync(id);
            IEnumerable<LanguageDtoModel> languagesDtoModel = await _languageService.GetLanguagesBySandboxIdAsync(id);

            SandboxViewModel viewModel = _mapper.MapSbStackLgFromDtoToView(sandboxDtoModel, languagesDtoModel, stackTechnologiesDtoModel);

            return await Task.FromResult(Ok(viewModel)); // convert to json?
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

                viewModels.Add(_mapper.MapSbStackLgFromDtoToView(item, languageDtoModels, stackTechnologyDtoModels));
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
                IEnumerable<StackTechnologyDtoModel> stackTechnologyDtoModels = await _stackTechnologyService.GetStackTechnologiesBySandboxIdAsync(item.Id);
                IEnumerable<LanguageDtoModel> languageDtoModels = await _languageService.GetLanguagesBySandboxIdAsync(item.Id);

                viewModels.Add(_mapper.MapSbStackLgFromDtoToView(item, languageDtoModels, stackTechnologyDtoModels));
            }

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(dtoPageListModels.TotalPages));
            return await Task.FromResult(Ok(viewModels));
        }

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] SandboxFieldsViewModel sandboxFields,
            [FromQuery] IEnumerable<Guid> languageIds,
            [FromQuery] IEnumerable<Guid> stackTechnologyIds)
        {
            Guid sandboxId = await _sandboxService.AddSandboxAsync(_mapper.MapSbFromViewToDto(sandboxFields));

            await _sandboxLanguageService.AddSandboxLanguagesListByIdsAsync(sandboxId, languageIds);
            await _sandboxStackTechnologyService.AddSandboxStackTechnologyListByIdsAsync(sandboxId, stackTechnologyIds);

            return await Task.FromResult(Ok());
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
