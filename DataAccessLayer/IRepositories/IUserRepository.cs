using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IUserRepository
    {
        IEnumerable<UserEntityModel> GetAll();
        IEnumerable<UserEntityModel> FindByCondition(Expression<Func<UserEntityModel, bool>> expression);
        void CreateAsync(UserEntityModel item);
        void UpdateAsync(UserEntityModel item);
        void DeleteAsync(int id);
    }
}
