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

        Task<IEnumerable<UserSandBoxEntityModel>> GetAllAsync(Func<IQueryable<UserSandBoxEntityModel>, IQueryable<UserSandBoxEntityModel>> include = null);
        Task<IEnumerable<UserSandBoxEntityModel>> FindByConditionAsync(Expression<Func<UserSandBoxEntityModel, bool>> expression);
        Task<UserSandBoxEntityModel> FindByIdAsync(int id);
        void CreateAsync(UserSandBoxEntityModel item);
        void UpdateAsync(UserSandBoxEntityModel item);
        void DeleteAsync(int id);
    }
}
