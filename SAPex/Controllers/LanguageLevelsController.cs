using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SAPex.Controllers;
using SAPex.Models;

namespace SAPex
{
    [Route("api/languagelevels")]
    [ApiController]
    public class LanguageLevelsController : ControllerBase
    {
        private readonly ILanguageLevelService _languageLevelService;

        public LanguageLevelsController(ILanguageLevelService service)
        {
            _languageLevelService = service;
        }

        [HttpGet]
        public async Task<IEnumerable<LanguageLevelDtoModel>> GetLenguageLevelAsync()
        {
            return await _languageLevelService.GetAllLanguageLevelsAsync();
        }
    }
}
