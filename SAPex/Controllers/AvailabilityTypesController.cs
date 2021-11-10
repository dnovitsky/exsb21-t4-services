using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SAPex.Controllers
{
    [Route("api/availabilitytypes")]
    [ApiController]
    public class AvailabilityTypesController : ControllerBase
    {
        private readonly IAvailabilityTypeService _availabilityTypeService;

        public AvailabilityTypesController(IAvailabilityTypeService service)
        {
            _availabilityTypeService = service;
        }

        [HttpGet]
        public async Task<IEnumerable<AvailabilityTypeDtoModel>> GetAvailabilityTypesAsync()
        {
            return await _availabilityTypeService.GetAllAvailabilitiesAsync();
        }
    }
}
