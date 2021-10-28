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
        void Create(UserEntityModel item);
        void Update(UserEntityModel item);
        void Delete(int id);
    }
}
