using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Service;
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

        // GET: api/<AvailabilityTypesController>
        [HttpGet]
        public async Task<IEnumerable<AvailabilityTypeDtoModel>> GetAvailabilityTypesAsync()
        {
            return await _availabilityTypeService.GetAllAvailabilitiesAsync();
        }

        [HttpGet("{pagesize}")]
        public async Task<PagedList<AvailabilityTypeDtoModel>> GetPageListAsync(int pagesize, int pagenumber)
        {
            return await _availabilityTypeService.GetPageListAsync(pagesize, pagenumber);
        }
    }
}
