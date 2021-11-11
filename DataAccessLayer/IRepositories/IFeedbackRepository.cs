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
        Task<IEnumerable<FeedbackEntityModel>> GetAllAsync();
        Task<IEnumerable<FeedbackEntityModel>> FindByConditionAsync(Expression<Func<FeedbackEntityModel, bool>> expression);
        Task<FeedbackEntityModel> FindByIdAsync(Guid id);

        Task<FeedbackEntityModel> CreateAsync(FeedbackEntityModel item);

        void Update(FeedbackEntityModel item);
        void Delete(Guid id);
    }
}
