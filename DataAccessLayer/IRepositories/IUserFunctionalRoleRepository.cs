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
        Task<IEnumerable<UserFunctionalRoleEntityModel>> GetAllAsync();
        Task<IEnumerable<UserFunctionalRoleEntityModel>> FindByConditionAsync(Expression<Func<UserFunctionalRoleEntityModel, bool>> expression);
        Task<UserFunctionalRoleEntityModel> FindByIdAsync(Guid id);
<<<<<<< HEAD
        void CreateAsync(UserFunctionalRoleEntityModel item);
=======
        Task<UserFunctionalRoleEntityModel> CreateAsync(UserFunctionalRoleEntityModel item);
>>>>>>> dev
        void Update(UserFunctionalRoleEntityModel item);
        void Delete(Guid id);
    }
}
