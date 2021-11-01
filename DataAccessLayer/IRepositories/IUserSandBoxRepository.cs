using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IUserSandBoxRepository
    {

        IEnumerable<UserSandBoxEntityModel> GetAll();
        IEnumerable<UserSandBoxEntityModel> FindByCondition(Expression<Func<UserSandBoxEntityModel, bool>> expression);
        void CreateAsync(UserSandBoxEntityModel item);
        void UpdateAsync(UserSandBoxEntityModel item);
        void DeleteAsync(int id);
    }
}
