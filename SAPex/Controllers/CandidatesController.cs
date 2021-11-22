using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Service;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SAPex.Controllers.Mapping;
using SAPex.Mappers;
using SAPex.Models;

namespace SAPex.Controllers
{
    [ApiController]
    [Route("api/candidates")]
    public class CandidatesController : ControllerBase
    {
        protected readonly CandidateMapper profile = new CandidateMapper();
        private readonly ICandidateService _service;
        private readonly InputParametrsMapper _inputParamersMapper;
        private readonly FilterParametrsMapper _filterParametrsMapper;

        public CandidatesController(ICandidateService service)
        {
            _service = service;
            _inputParamersMapper = new InputParametrsMapper();
            _filterParametrsMapper = new FilterParametrsMapper();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<CandidateDtoModel> candiddatesDto = await _service.GetAllCandidateAsync();

            if (candiddatesDto != null)
            {
                var candidatesVM = profile.MapCandidateDtoToVM(candiddatesDto);

                return await Task.FromResult(Ok(candidatesVM));
            }

            return await Task.FromResult(Conflict());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            CandidateDtoModel candiddateDto = await _service.FindCandidateByIdAsync(id);

            if (candiddateDto != null)
            {
                var candidateVM = profile.MapCandidateDtoToVM(candiddateDto);

                return await Task.FromResult(Ok(candidateVM));
            }

            return await Task.FromResult(Conflict());
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] CreateCandidateViewModel requestData)
        {
            var candidate = await _service.AddCandidateAsync(profile.MapNewCandidateToDto(requestData));

            if (candidate != null)
            {
                return await Task.FromResult(Ok(candidate));
            }

            return await Task.FromResult(Conflict());
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetFilter([FromQuery] InputParametrsViewModel sandboxParametrs, [FromQuery] FilterParametrsViewModel filterParametrs)
        {
            PagedList<CandidateDtoModel> dtoPageListModels = await _service.GetPagedSandboxesAsync(
                _inputParamersMapper.MapFromViewToDto(sandboxParametrs),
                _filterParametrsMapper.MapFromViewToDto(filterParametrs));

            IList<CandidateViewModel> viewModels = new List<CandidateViewModel>();

            foreach (var item in dtoPageListModels.PageList)
            {
                /*
                IEnumerable<StackTechnologyDtoModel> stackTechnologyDtoModels = await _stackTechnologyService.GetStackTechnologiesBySandboxIdAsync(item.Id);
                IEnumerable<LanguageDtoModel> languageDtoModels = await _languageService.GetLanguagesBySandboxIdAsync(item.Id);

                viewModels.Add(_mapper.MapSbStackLgFromDtoToView(item, languageDtoModels, stackTechnologyDtoModels));
                */
                viewModels.Add(profile.MapCandidateDtoToVM(item));
            }

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(dtoPageListModels.TotalPages));
            return await Task.FromResult(Ok(viewModels));
        }

        [HttpPut("{id}")]
        public void Put([FromRoute] Guid id, [FromBody] CandidateViewModel updateCandidateFields)
        {
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] Guid id)
        {
        }
    }
}
