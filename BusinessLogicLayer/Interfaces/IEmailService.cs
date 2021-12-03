using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEmailService
    {
        public Task<IEnumerable<EmailDtoModel>> GetAllAsync();
        public Task<EmailDtoModel> CreateAsync(EmailDtoModel email);
        public Task<EmailDtoModel> UpdateAsync(EmailDtoModel email);
    }
}
