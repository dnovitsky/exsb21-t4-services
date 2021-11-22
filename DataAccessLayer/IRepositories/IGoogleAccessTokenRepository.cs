using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IGoogleAccessTokenRepository
    {
        Task<IEnumerable<GoogleAccessTokenEntityModel>> GetAllAsync();
        Task<IEnumerable<GoogleAccessTokenEntityModel>> FindByConditionAsync(Expression<Func<GoogleAccessTokenEntityModel, bool>> expression);
        Task<GoogleAccessTokenEntityModel> FindByIdAsync(Guid id);

        Task<GoogleAccessTokenEntityModel> CreateAsync(GoogleAccessTokenEntityModel item);

        void Update(GoogleAccessTokenEntityModel item);
        void Delete(Guid id);
    }
}
