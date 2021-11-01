using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IRatingRepository
    {
        IEnumerable<RatingEntityModel> GetAll();
        IEnumerable<RatingEntityModel> FindByCondition(Expression<Func<RatingEntityModel, bool>> expression);
        void CreateAsync(RatingEntityModel item);
        void UpdateAsync(RatingEntityModel item);
        void DeleteAsync(int id);
    }
}
