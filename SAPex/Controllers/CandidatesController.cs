using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using SAPex.Controllers.Mapping;
using SAPex.Models;

namespace SAPex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        protected readonly CandidateProfile profile = new CandidateProfile();
        private readonly ICandidateService _service;

        public CandidatesController(ICandidateService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<CandidateViewModel> Get()
        {
            // var newDto = new List<CandidateDtoModel>() { };
            // var listViewM = profile.MapListToController<CandidateDtoModel, CandidateViewModel>(newDto);

            // --
            // --

            return new List<CandidateViewModel>();
        }

        [HttpGet("{id}")]
        public CandidateViewModel Get([FromRoute] Guid id)
        {
            // var newDto = new CandidateDtoModel() { };
            // var candidateDto = profile.MapFromT1ToT2o<CandidateDtoModel, CandidateViewModel>(newDto);

            // --
            // --

            return new CandidateViewModel();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCandidateViewModel requestData)
        {
            await _service.AddCandidateAsync(profile.MapNewCandidateToDto(requestData));

            return await Task.FromResult(Ok());
        }

        [HttpPut("{id}")]
        public void Put([FromRoute] Guid id, [FromBody] CandidateViewModel updateCandidateFields)
        {
            // var candidateDto = profile.MapFromT1ToT2o<CandidateViewModel, CandidateDtoModel>(updateCandidateFields);

            // --
            // --
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] Guid id)
        {
        }
    }
}
