using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface IUserCandidateSandboxRepository
    {
        Task<IEnumerable<UserCandidateSandboxEntityModel>> GetAllAsync();
        Task<IEnumerable<UserCandidateSandboxEntityModel>> FindByConditionAsync(Expression<Func<UserCandidateSandboxEntityModel, bool>> expression);
        Task<UserCandidateSandboxEntityModel> FindByIdAsync(Guid id);
        Task<UserCandidateSandboxEntityModel> CreateAsync(UserCandidateSandboxEntityModel item);
        void Update(UserCandidateSandboxEntityModel item);
        void Delete(Guid id);
        void DeleteRange(IEnumerable<UserCandidateSandboxEntityModel> items);
    }
}
