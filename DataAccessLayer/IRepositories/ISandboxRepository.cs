using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ISandboxRepository
    {
        Task<IEnumerable<SandboxEntityModel>> GetAllAsync(Func<IQueryable<SandboxEntityModel>, IQueryable<SandboxEntityModel>> include = null);
        Task<IEnumerable<SandboxEntityModel>> FindByConditionAsync(Expression<Func<SandboxEntityModel, bool>> expression);
        Task<SandboxEntityModel> FindByIdAsync(int id);
        void CreateAsync(SandboxEntityModel item);
        void UpdateAsync(SandboxEntityModel item);
        void DeleteAsync(int id);
    }
}
