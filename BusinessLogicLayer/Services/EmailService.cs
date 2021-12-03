using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using DbMigrations.EntityModels.DataTypes;

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
        public async Task<EmailDtoModel> GetByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.Emails.FindByIdAsync(id);
            return _mapper.Map<EmailDtoModel>(entity);
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

        
    }
}
