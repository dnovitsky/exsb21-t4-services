using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IUserRoleRepository
    {
        IEnumerable<UserRoleEntityModel> GetAll();
        IEnumerable<UserRoleEntityModel> FindByCondition(Expression<Func<UserRoleEntityModel, bool>> expression);
        void Create(UserRoleEntityModel item);
        void Update(UserRoleEntityModel item);
        void Delete(int id);
    }
}
