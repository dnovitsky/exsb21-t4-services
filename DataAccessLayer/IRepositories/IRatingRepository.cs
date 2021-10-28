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
        void Create(RatingEntityModel item);
        void Update(RatingEntityModel item);
        void Delete(int id);
    }
}
