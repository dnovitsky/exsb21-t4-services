using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IUserSandBoxRepository
    {

        Task<IEnumerable<UserSandBoxEntityModel>> GetAllAsync();
        Task<IEnumerable<UserSandBoxEntityModel>> FindByConditionAsync(Expression<Func<UserSandBoxEntityModel, bool>> expression);
        Task<UserSandBoxEntityModel> FindByIdAsync(Guid id);
<<<<<<< HEAD
        void CreateAsync(UserSandBoxEntityModel item);
=======
        Task<UserSandBoxEntityModel> CreateAsync(UserSandBoxEntityModel item);
>>>>>>> dev
        void Update(UserSandBoxEntityModel item);
        void Delete(Guid id);
    }
}
