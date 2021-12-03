using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
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

        [HttpGet]
        public async Task<IEnumerable<EmailViewModel>> GetAllAsync()
        {
            var emails = await _emailService.GetAllAsync();
            return _mapper.Map<IEnumerable<EmailViewModel>>(emails);
        }

        [HttpPost]
        public async Task<EmailViewModel> CreateAsync([FromBody] EmailViewModel email)
        {
            var dto = _mapper.Map<EmailDtoModel>(email);
            dto = await _emailService.CreateAsync(dto);
            return _mapper.Map<EmailViewModel>(dto);
        }

        [HttpPut]
        public async Task<EmailViewModel> UpdateAsync([FromBody] EmailViewModel email)
        {
            var dto = _mapper.Map<EmailDtoModel>(email);
            dto = await _emailService.UpdateAsync(dto);
            return _mapper.Map<EmailViewModel>(dto);
        }
    }
}
