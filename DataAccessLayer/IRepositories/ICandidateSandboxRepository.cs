using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ICandidateSandboxRepository
    {
        Task<IEnumerable<CandidateSandboxEntityModel>> GetAllAsync(Func<IQueryable<CandidateSandboxEntityModel>, IQueryable<CandidateSandboxEntityModel>> include = null);
        Task<IEnumerable<CandidateSandboxEntityModel>> FindByConditionAsync(Expression<Func<CandidateSandboxEntityModel, bool>> expression);
        Task<CandidateSandboxEntityModel> FindByIdAsync(int id);
        void CreateAsync(CandidateSandboxEntityModel item);
        void UpdateAsync(CandidateSandboxEntityModel item);
        void DeleteAsync(int id);
    }
}
