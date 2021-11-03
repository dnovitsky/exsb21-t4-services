using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntityModel>> GetAllAsync();
        Task<IEnumerable<UserEntityModel>> FindByConditionAsync(Expression<Func<UserEntityModel, bool>> expression);
        Task<UserEntityModel> FindByIdAsync(int id);
        void CreateAsync(UserEntityModel item);
        void Update(UserEntityModel item);
        void Delete(int id);
    }
}
