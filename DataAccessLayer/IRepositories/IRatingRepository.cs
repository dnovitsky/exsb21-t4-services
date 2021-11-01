using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IRatingRepository
    {
        Task<IEnumerable<RatingEntityModel>> GetAllAsync(Func<IQueryable<RatingEntityModel>, IQueryable<RatingEntityModel>> include = null);
        Task<IEnumerable<RatingEntityModel>> FindByConditionAsync(Expression<Func<RatingEntityModel, bool>> expression);
        Task<RatingEntityModel> FindByIdAsync(int id);
        void CreateAsync(RatingEntityModel item);
        void UpdateAsync(RatingEntityModel item);
        void DeleteAsync(int id);
    }
}
