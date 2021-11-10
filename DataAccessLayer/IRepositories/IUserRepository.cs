using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntityModel>> GetAllAsync();
        Task<IEnumerable<UserEntityModel>> FindByConditionAsync(Expression<Func<UserEntityModel, bool>> expression);
        Task<UserEntityModel> FindByIdAsync(Guid id);
<<<<<<< HEAD
        void CreateAsync(UserEntityModel item);
=======
        Task<UserEntityModel> CreateAsync(UserEntityModel item);
>>>>>>> dev
        void Update(UserEntityModel item);
        void Delete(Guid id);
    }
}
