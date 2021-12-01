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
        private readonly CandidateFilterParametrsMapper _candidateFilterParametrsMapper;

        public CandidatesController(ICandidateService service)
        {
            _service = service;
            _inputParamersMapper = new InputParametrsMapper();
            _candidateFilterParametrsMapper = new CandidateFilterParametrsMapper();
        }

        [HttpGet]
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCandidateViewModel requestData)
        {
            var candiddateDto = await _service.AddCandidateAsync(profile.MapNewCandidateToDto(requestData));

            if (candiddateDto != null)
            {
                var candidateVM = profile.MapCandidateDtoToVM(candiddateDto);
                return await Task.FromResult(Ok(candidateVM));
            }

            return await Task.FromResult(Conflict());
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetFilter([FromQuery] InputParametrsViewModel inputParametrs, [FromQuery] CandidateFilterParametrsViewModel candidateFilterParametrs)
        {
            PagedList<CandidateDtoModel> dtoPageListModels = await _service.GetPagedCandidatesAsync(
                _inputParamersMapper.MapFromViewToDto(inputParametrs),
                _candidateFilterParametrsMapper.MapFromViewToDto(candidateFilterParametrs));

            IList<CandidateViewModel> viewModels = new List<CandidateViewModel>();

            foreach (var item in dtoPageListModels.PageList)
            {
                viewModels.Add(profile.MapCandidateDtoToVM(item));
            }

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(dtoPageListModels.TotalPages));
            Response.Headers.Add("X-Total-Page-Items", JsonConvert.SerializeObject(dtoPageListModels.TotalPageItems));
            return await Task.FromResult(Ok(viewModels));
        }

        [HttpPut("{candidateSandboxId}")]
        public async Task<IActionResult> Put([FromRoute] Guid candidateSandboxId, [FromQuery] Guid newStatusId)
        {
            var isUpdatedo = await _service.UpdateCandidateStatus(candidateSandboxId, newStatusId);

            IActionResult actionResult = isUpdatedo ? Ok() : Conflict();

            return await Task.FromResult(actionResult);
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] Guid id)
        {
        }
    }
}
