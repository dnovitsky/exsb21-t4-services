using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IFeedbackRepository
    {
        IEnumerable<FeedbackEntityModel> GetAll();
        IEnumerable<FeedbackEntityModel> FindByCondition(Expression<Func<FeedbackEntityModel, bool>> expression);
        void CreateAsync(FeedbackEntityModel item);
        void UpdateAsync(FeedbackEntityModel item);
        void DeleteAsync(int id);
    }
}
