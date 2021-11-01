using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<FeedbackEntityModel>> GetAllAsync(Func<IQueryable<FeedbackEntityModel>, IQueryable<FeedbackEntityModel>> include = null);
        Task<IEnumerable<FeedbackEntityModel>> FindByConditionAsync(Expression<Func<FeedbackEntityModel, bool>> expression);
        Task<FeedbackEntityModel> FindByIdAsync(int id);
        void CreateAsync(FeedbackEntityModel item);
        void UpdateAsync(FeedbackEntityModel item);
        void DeleteAsync(int id);
    }
}
