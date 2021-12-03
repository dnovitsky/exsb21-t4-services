using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using DbMigrations.EntityModels.DataTypes;
using SAPexSMTPMailService.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class EmailService : IEmailService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISendMailService _mailService;

        public EmailService(IUnitOfWork unitOfWork, ISendMailService mailService, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mailService = mailService;
        }

        public async Task<IEnumerable<EmailDtoModel>> GetAllFilterAsync(EmailStatusType status)
        {
            var emails = await _unitOfWork.Emails.FindByConditionAsync(x=>x.Status == status);
            return _mapper.Map<IEnumerable<EmailDtoModel>>(emails);
        }

        public async Task<EmailDtoModel> CreateAsync(EmailDtoModel email)
        {
            var emailEntity = _mapper.Map<EmailEntityModel>(email);
            email = _mapper.Map<EmailDtoModel>(await _unitOfWork.Emails.CreateAsync(emailEntity));
            await _unitOfWork.SaveAsync();
            return email;
        }

        public async Task<EmailDtoModel> UpdateAsync(Guid id, EmailDtoModel email)
        {
            var emailById = await _unitOfWork.Emails.FindByIdAsync(id);
            if (emailById != null)
            {
                emailById.EmailFrom = email.EmailFrom;
                emailById.Head = email.Head;
                emailById.Message = email.Message;
                emailById.EmailTo = email.EmailTo;
                emailById.Status = email.Status;
                _unitOfWork.Emails.Update(emailById);
                await _unitOfWork.SaveAsync();
                return _mapper.Map<EmailDtoModel>(emailById);
            }
            return null;
        }

        public async Task<bool> SendAsync(Guid id)
        {
            var emailEntity = await _unitOfWork.Emails.FindByIdAsync(id);
            if (emailEntity != null)
            {
                var emailDto = _mapper.Map<EmailDtoModel>(emailEntity);
                emailDto.Status = EmailStatusType.InProcess;
                await UpdateAsync(emailEntity.Id, emailDto);
                bool sent = _mailService.MainProcess(emailDto.Head, emailDto.Message, emailDto.EmailTo);
                if (sent)
                {
                    emailDto.Status = EmailStatusType.Sent;
                    await UpdateAsync(emailDto.Id, emailDto);
                    return true;
                }
            }
            return false;
        }
    }
}
