using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IUserRefreshTokenRepository
    {
        Task<IEnumerable<UserRefreshTokenEntityModel>> GetAllAsync();
        Task<IEnumerable<UserRefreshTokenEntityModel>> FindByConditionAsync(Expression<Func<UserRefreshTokenEntityModel, bool>> expression);
        Task<UserRefreshTokenEntityModel> FindByIdAsync(Guid id);
        void CreateAsync(UserRefreshTokenEntityModel item);
        void Update(UserRefreshTokenEntityModel item);
        void Delete(int id);
    }
}
