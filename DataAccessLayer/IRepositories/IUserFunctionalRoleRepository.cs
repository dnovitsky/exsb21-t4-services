using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IUserFunctionalRoleRepository
    {
        IEnumerable<UserFunctionalRoleEntityModel> GetAll();
        IEnumerable<UserFunctionalRoleEntityModel> FindByCondition(Expression<Func<UserFunctionalRoleEntityModel, bool>> expression);
        void CreateAsync(UserFunctionalRoleEntityModel item);
        void UpdateAsync(UserFunctionalRoleEntityModel item);
        void DeleteAsync(int id);
    }
}
