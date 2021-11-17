using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SAPex.Mappers;
using SAPex.Models;

namespace SAPex.Controllers
{
    [Route("api/languages")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _service;
        private readonly LanguageMapper _mapper;

        public LanguagesController(ILanguageService service)
        {
            _service = service;
            _mapper = new LanguageMapper();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            LanguageDtoModel dtoModel = await _service.FindLanguageByIdAsync(id);

            if (dtoModel == null)
            {
                return await Task.FromResult(NotFound());
            }

            LanguageViewModel viewModel = _mapper.MapLanguageFromDtoToView(dtoModel);

            return await Task.FromResult(Ok(viewModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<LanguageDtoModel> dtoModels = await _service.GetAllLanguagesAsync();

            IEnumerable<LanguageViewModel> viewModels = _mapper.MapListLanguageFromDtoToView(dtoModels);

            return await Task.FromResult(Ok(viewModels));
        }
    }
}
