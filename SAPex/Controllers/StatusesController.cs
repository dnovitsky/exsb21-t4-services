using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SAPex.Mappers;

namespace SAPex.Controllers
{
    [ApiController]
    [Route("api/statuses")]
    public class StatusesController : ControllerBase
    {
        protected readonly StatusMapper profile = new StatusMapper();
        private readonly IStatusService _service;

        public StatusesController(IStatusService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<StatusDtoModel> statusesDto = await _service.GetAllStatusesAsync();

            if (statusesDto != null)
            {
                var statusesVM = profile.MapListToView(statusesDto);

                return await Task.FromResult(Ok(statusesVM));
            }

            return await Task.FromResult(Conflict());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            StatusDtoModel statusDto = await _service.FindStatusByIdAsync(id);

            if (statusDto != null)
            {
                var statusVM = profile.MapDtoToView(statusDto);

                return await Task.FromResult(Ok(statusVM));
            }

            return await Task.FromResult(Conflict());
        }
    }
}
