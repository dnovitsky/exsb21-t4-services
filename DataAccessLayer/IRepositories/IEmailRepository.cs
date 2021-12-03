using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IEmailRepository
    {
        Task<IEnumerable<EmailEntityModel>> GetAllAsync();
        Task<IEnumerable<EmailEntityModel>> FindByConditionAsync(Expression<Func<EmailEntityModel, bool>> expression);
        Task<EmailEntityModel> FindByIdAsync(Guid id);
        Task<EmailEntityModel> CreateAsync(EmailEntityModel item);
        void Update(EmailEntityModel item);
        void Delete(Guid id);
    }
}
