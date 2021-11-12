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
        private readonly SandboxMapper _mapper;
        private readonly InputParametrsMapper _inputParamersMapper;

        public SandboxesController(ISandboxService sandboxService, IStackTechnologyService stackTechnologyService, ILanguageService languageService)
        {
            _sandboxService = sandboxService;
            _stackTechnologyService = stackTechnologyService;
            _languageService = languageService;
            _mapper = new SandboxMapper();
            _inputParamersMapper = new InputParametrsMapper();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            SandboxDtoModel sandboxDtoModel = await _sandboxService.FindSandboxByIdAsync(id); // on what level goes null check? it should go directly to db?
            IEnumerable<StackTechnologyDtoModel> stackTechnologyDtoModel = await _stackTechnologyService.GetStackTechnologiesBySandboxIdAsync(id);
            IEnumerable<LanguageDtoModel> languageDtoModel = await _languageService.GetLanguagesBySandboxIdAsync(id);

            SandboxViewModel viewModel = _mapper.MapSbStackLgFromDtoToView(sandboxDtoModel, languageDtoModel, stackTechnologyDtoModel);

            return await Task.FromResult(Ok(viewModel)); // convert to json?
        }

        [HttpGet]
        public async Task<IActionResult> GetByPage(int pagenumber = 1, int pagesize = 10, string searchstring = "d", string sortfield = "name", int sorttype = 1)
        {
            // do not know why method does not work with class [FromRoute] InputParametrsViewModel sandboxParametrs
            InputParametrsViewModel sandboxParametrs = new InputParametrsViewModel { PageNumber = pagenumber, PageSize = pagesize, SearchingString = searchstring, SortField = sortfield, SortType = sorttype };
            PagedList<SandboxDtoModel> dtoModels = await _sandboxService.GetPagedSandboxesAsync(_inputParamersMapper.MapFromViewToDto(sandboxParametrs));

            IList<SandboxViewModel> viewModels = new List<SandboxViewModel>(); // = _mapper.MapListSbFromDtoToView(dtoModels);

            foreach (var a in dtoModels.PageList)
            {
                IEnumerable<StackTechnologyDtoModel> stackTechnologyDtoModel = await _stackTechnologyService.GetStackTechnologiesBySandboxIdAsync(a.Id);
                IEnumerable<LanguageDtoModel> languageDtoModel = await _languageService.GetLanguagesBySandboxIdAsync(a.Id);

                viewModels.Add(_mapper.MapSbStackLgFromDtoToView(a, languageDtoModel, stackTechnologyDtoModel));
            }

            return await Task.FromResult(Ok(viewModels));
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

            // foreach (var a in ids)
            // {
            //    Console.WriteLine(a);
            // }

            await _sandboxService.AddSandboxAsync(_mapper.MapSbFromViewToDto(requestData)); // where is check on already exists

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
