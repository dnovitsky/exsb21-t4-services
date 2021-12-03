using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Services
{
    public class EmailService : IEmailService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EmailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EmailDtoModel>> GetAllAsync()
        {
            var emails = await _unitOfWork.Emails.GetAllAsync();
            return _mapper.Map<IEnumerable<EmailDtoModel>>(emails);
        }

        public async Task<EmailDtoModel> CreateAsync(EmailDtoModel email)
        {
            var emailEntity = _mapper.Map<EmailEntityModel>(email);
            email = _mapper.Map<EmailDtoModel>(await _unitOfWork.Emails.CreateAsync(emailEntity));
            await _unitOfWork.SaveAsync();
            return email;
        }

        public async Task<EmailDtoModel> UpdateAsync(EmailDtoModel email)
        {
            var emailEntity = _mapper.Map<EmailEntityModel>(email);
            _unitOfWork.Emails.Update(emailEntity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<EmailDtoModel>(emailEntity);
        }




    }
}
