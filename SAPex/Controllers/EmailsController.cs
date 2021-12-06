using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using DbMigrations.EntityModels.DataTypes;
using Microsoft.AspNetCore.Mvc;
using SAPex.Models;
using SAPexSMTPMailService.Interfaces;

namespace SAPex.Controllers
{
    [ApiController]
    [Route("api/emails")]
    public class EmailsController : ControllerBase
    {
        private readonly ISendMailService _mailService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public EmailsController(IEmailService emailService, ISendMailService mailService, IMapper mapper)
        {
            _mailService = mailService;
            _emailService = emailService;
            _mapper = mapper;
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<EmailViewModel>>> GetAllFilterAsync([FromQuery] EmailStatusType status = EmailStatusType.ReadyForSend)
        {
            var emails = await _emailService.GetAllFilterAsync(status);
            if (emails.Any())
            {
                return Ok(_mapper.Map<IEnumerable<EmailViewModel>>(emails));
            }

            return NoContent();
        }

        [HttpPut("{id}/send")]
        public async Task<IActionResult> SendAsync([FromRoute] Guid id)
        {
            var emailDto = await _emailService.GetByIdAsync(id);

            if (emailDto == null)
            {
                return NotFound();
            }

            emailDto.Status = EmailStatusType.InProcess;
            await _emailService.UpdateAsync(id, emailDto);
            bool sent = _mailService.MainProcess(emailDto.Head, emailDto.Message, emailDto.EmailTo);
            if (sent)
            {
                emailDto.Status = EmailStatusType.Sent;
                await _emailService.UpdateAsync(id, emailDto);
                return Ok();
            }
            else
            {
                emailDto.Status = EmailStatusType.Fail;
                await _emailService.UpdateAsync(id, emailDto);
                return BadRequest();
            }
        }
    }
}
