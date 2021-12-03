using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using DbMigrations.EntityModels.DataTypes;
using Microsoft.AspNetCore.Mvc;
using SAPex.Models;

namespace SAPex.Controllers
{
    [ApiController]
    [Route("api/emails")]
    public class EmailsController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public EmailsController(IEmailService emailService, IMapper mapper)
        {
            _emailService = emailService;
            _mapper = mapper;
        }

        [HttpGet("filter")]
        public async Task<IEnumerable<EmailViewModel>> GetAllFilterAsync([FromQuery] EmailStatusType status = EmailStatusType.ReadyForSend)
        {
            var emails = await _emailService.GetAllFilterAsync(status);
            return _mapper.Map<IEnumerable<EmailViewModel>>(emails);
        }

        [HttpPut("{id}/send")]
        public async Task<IActionResult> SendAsync([FromRoute] Guid id)
        {
            var isSent = await _emailService.SendAsync(id);
            if (isSent)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
