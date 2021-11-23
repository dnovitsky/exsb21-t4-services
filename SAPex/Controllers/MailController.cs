using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SAPexSMTPMailService.Interfaces;
using SAPexSMTPMailService.Services;

namespace SAPex.Controllers
{
    [Route("api/mails")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly ISendMailService _sendMail;

        public MailController(ISendMailService service)
        {
            _sendMail = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(string head, string message, string mailTo)
        {
            bool test = _sendMail.MainProcess(head, message, mailTo);

            if (test)
            {
                return await Task.FromResult(Ok());
            }

            return await Task.FromResult(BadRequest());
        }
    }
}
