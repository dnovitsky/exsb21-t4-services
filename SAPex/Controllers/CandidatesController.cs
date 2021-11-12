using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SAPex.Controllers.Mapping;
using SAPex.Models;

namespace SAPex.Controllers
{
    [ApiController]
    [Route("api/candidates")]
    public class CandidatesController : ControllerBase
    {
        protected readonly CandidateMapper profile = new CandidateMapper();
        private readonly ICandidateService _service;

        public CandidatesController(ICandidateService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<CandidateViewModel> Get()
        {
            return new List<CandidateViewModel>();
        }

        [HttpGet("{id}")]
        public CandidateViewModel Get([FromRoute] Guid id)
        {
            return new CandidateViewModel();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCandidateViewModel requestData)
        {
            var isCandidateCreated = await _service.AddCandidateAsync(profile.MapNewCandidateToDto(requestData));

            if (isCandidateCreated)
            {
                return await Task.FromResult(Ok());
            }

            return await Task.FromResult(Conflict());
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
