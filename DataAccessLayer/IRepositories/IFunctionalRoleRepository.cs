using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IFunctionalRoleRepository
    {
        Task<IEnumerable<FunctionalRoleEntityModel>> GetAllAsync(Func<IQueryable<FunctionalRoleEntityModel>, IQueryable<FunctionalRoleEntityModel>> include = null);
        Task<IEnumerable<FunctionalRoleEntityModel>> FindByConditionAsync(Expression<Func<FunctionalRoleEntityModel, bool>> expression);
        Task<FunctionalRoleEntityModel> FindByIdAsync(int id);
        void CreateAsync(FunctionalRoleEntityModel item);
        void UpdateAsync(FunctionalRoleEntityModel item);
        void DeleteAsync(int id);
    }
}
