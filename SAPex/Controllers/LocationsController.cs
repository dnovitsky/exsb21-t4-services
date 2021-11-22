using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SAPex.Mappers;

namespace SAPex.Controllers
{
    [ApiController]
    [Route("api/locations")]
    public class LocationsController : ControllerBase
    {
        protected readonly LocationMapper profile = new LocationMapper();
        private readonly ILocationService _service;

        public LocationsController(ILocationService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<LocationDtoModel> locationDto = await _service.GetAllLocationsAsync();

            if (locationDto != null)
            {
                var candidatesVM = profile.MapListLocationFromDtoToView(locationDto);

                return await Task.FromResult(Ok(candidatesVM));
            }

            return await Task.FromResult(Conflict());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            LocationDtoModel locationDto = await _service.FindLocationByIdAsync(id);

            if (locationDto != null)
            {
                var locationVM = profile.MapLocationFromDtoToView(locationDto);

                return await Task.FromResult(Ok(locationVM));
            }

            return await Task.FromResult(Conflict());
        }
    }
}
