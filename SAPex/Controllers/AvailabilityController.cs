using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAPex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        private readonly IAvailabilityService _availabilityService;

        public AvailabilityController(IAvailabilityService service)
        {
            _availabilityService = service;
        }

        // GET: api/<AvailabilityController>
        [HttpGet]
        public async Task<IEnumerable<AvailabilityDtoModel>> GetAvailabilitiesAsync()
        {
            return await _availabilityService.GetAllAvailabilitiesAsync();
        }
    }
}
