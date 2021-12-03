using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels.DataTypes;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEmailService
    {
        public Task<IEnumerable<EmailDtoModel>> GetAllFilterAsync(EmailStatusType status);
        public Task<EmailDtoModel> CreateAsync(EmailDtoModel email);
        public Task<EmailDtoModel> UpdateAsync(Guid id, EmailDtoModel email);
        public Task<EmailDtoModel> GetByIdAsync(Guid id);
    }
}
