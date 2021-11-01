using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IUserFunctionalRoleRepository
    {
        Task<IEnumerable<UserFunctionalRoleEntityModel>> GetAllAsync(Func<IQueryable<UserFunctionalRoleEntityModel>, IQueryable<UserFunctionalRoleEntityModel>> include = null);
        Task<IEnumerable<UserFunctionalRoleEntityModel>> FindByConditionAsync(Expression<Func<UserFunctionalRoleEntityModel, bool>> expression);
        Task<UserFunctionalRoleEntityModel> FindByIdAsync(int id);
        void CreateAsync(UserFunctionalRoleEntityModel item);
        void UpdateAsync(UserFunctionalRoleEntityModel item);
        void DeleteAsync(int id);
    }
}
