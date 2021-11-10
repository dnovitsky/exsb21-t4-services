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
    [Route("api/sandbox")]
    [ApiController]
    public class SandboxesController : ControllerBase
    {
        private readonly ISandboxService _service;
        private readonly SandboxMapper _mapper;

        public SandboxesController(ISandboxService service)
        {
            _service = service;
            _mapper = new SandboxMapper();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            SandboxDtoModel dtoModel = await _service.FindSandboxByIdAsync(id); // on what level goes null check? it should go directly to db?

            if (dtoModel == null)
            {
                return await Task.FromResult(NotFound());
            }

            SandboxViewModel viewModel = _mapper.MapSbFromDtoToView(dtoModel);

            return await Task.FromResult(Ok(viewModel)); // convert to json?
        }

        [HttpGet]
        public async Task<IActionResult> GetByPage(int pageNumber = 1, int pageSize = 5, string sortOrder = "name", string searchString = "")
        {
            IEnumerable<SandboxDtoModel> dtoModels = await _service.GetAllSandboxesAsync(); // on what level goes null check? it should go directly to db?

            if (dtoModels == null)
            {
                return await Task.FromResult(NotFound()); // return null
            }

            IEnumerable<SandboxViewModel> viewModels = _mapper.MapListSbFromDtoToView(dtoModels);

            if (!string.IsNullOrEmpty(searchString))
            {
                viewModels = viewModels.Where(s => s.Description.Contains(searchString)
                                       || s.Name.Contains(searchString));
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

            await _service.AddSandboxAsync(_mapper.MapSbFromViewToDto(requestData)); // where is check on already exists

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
