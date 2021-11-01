using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ISandboxStackTechnologyRepository
    {
        Task<IEnumerable<SandboxStackTechnologyEntityModel>> GetAllAsync(Func<IQueryable<SandboxStackTechnologyEntityModel>, IQueryable<SandboxStackTechnologyEntityModel>> include = null);
        Task<IEnumerable<SandboxStackTechnologyEntityModel>> FindByConditionAsync(Expression<Func<SandboxStackTechnologyEntityModel, bool>> expression);
        Task<SandboxStackTechnologyEntityModel> FindByIdAsync(int id);
        void CreateAsync(SandboxStackTechnologyEntityModel item);
        void UpdateAsync(SandboxStackTechnologyEntityModel item);
        void DeleteAsync(int id);
    }
}
