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
using SAPex.Helpers;
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
        private readonly TestTaskEmailForCandidateProcess _testTaskEmailForCandidateProcess;

        public CandidatesController(ICandidateService service, TestTaskEmailForCandidateProcess testTaskEmailForCandidateProcess)
        {
            _service = service;
            _inputParamersMapper = new InputParametrsMapper();
            _candidateFilterParametrsMapper = new CandidateFilterParametrsMapper();
            _testTaskEmailForCandidateProcess = testTaskEmailForCandidateProcess;
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

        [HttpPut("{id}/candidatesandboxes/{candidateSandboxId}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromRoute] Guid candidateSandboxId, [FromQuery] Guid newStatusId)
        {
            var isUpdated = await _service.UpdateCandidateStatus(id, candidateSandboxId, newStatusId);

            IActionResult actionResult = isUpdated ? Ok() : Conflict();

            return await Task.FromResult(actionResult);
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] Guid id)
        {
        }

        [HttpPost("send-test-task")]
        public async Task<IActionResult> Post([FromBody] IList<Guid> processIdList)
        {
            try
            {
                var tokens = await _testTaskEmailForCandidateProcess.GetCandidateProcessTestTaskTokens(processIdList, DateTime.UtcNow);

                // call email service

                return await Task.FromResult(Ok());
            }
            catch (Exception ex)
            {
                return await Task.FromResult(Conflict());
            }
        }
    }
}
