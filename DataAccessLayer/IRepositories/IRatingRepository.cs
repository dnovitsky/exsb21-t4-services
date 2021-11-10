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
        Task<IEnumerable<RatingEntityModel>> GetAllAsync();
        Task<IEnumerable<RatingEntityModel>> FindByConditionAsync(Expression<Func<RatingEntityModel, bool>> expression);
        Task<RatingEntityModel> FindByIdAsync(Guid id);
<<<<<<< HEAD
        void CreateAsync(RatingEntityModel item);
=======
        Task<RatingEntityModel> CreateAsync(RatingEntityModel item);
>>>>>>> dev
        void Update(RatingEntityModel item);
        void Delete(Guid id);
    }
}
