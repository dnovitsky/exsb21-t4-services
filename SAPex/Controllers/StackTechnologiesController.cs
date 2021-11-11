using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using SAPex.Mappers;
using SAPex.Models;

namespace SAPex.Controllers
{
    [Route("api/stacktechnologies")]
    [ApiController]
    public class StackTechnologiesController : ControllerBase
    {
        private readonly IStackTechnologyService _service;
        private readonly StackTechnologyMapper _mapper;

        public StackTechnologiesController(IStackTechnologyService service)
        {
            _service = service;
            _mapper = new StackTechnologyMapper();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            StackTechnologyDtoModel dtoModel = await _service.FindStackTechnologyByIdAsync(id);

            if (dtoModel == null)
            {
                return await Task.FromResult(NotFound());
            }

            StackTechnologyViewModel viewModel = _mapper.MapStackTechnologyFromDtoToView(dtoModel);

            return await Task.FromResult(Ok(viewModel)); // convert to json?
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<StackTechnologyDtoModel> dtoModels = await _service.GetAllStackTechnologiesAsync(); // on what level goes null check? it should go directly to db?

            if (dtoModels == null)
            {
                return await Task.FromResult(NotFound()); // return null
            }

            IEnumerable<StackTechnologyViewModel> viewModels = _mapper.MapListStackTechnologyFromDtoToView(dtoModels);

            return await Task.FromResult(Ok(viewModels));
        }
    }
}
