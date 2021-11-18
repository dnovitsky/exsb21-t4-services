using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IInterviewEventRepository
    {
        Task<IEnumerable<InterviewEventEntityModel>> GetAllAsync();
        Task<IEnumerable<InterviewEventEntityModel>> FindByConditionAsync(Expression<Func<InterviewEventEntityModel, bool>> expression);
        Task<InterviewEventEntityModel> FindByIdAsync(Guid id);
        Task<InterviewEventEntityModel> CreateAsync(InterviewEventEntityModel item);
        void Update(InterviewEventEntityModel item);
        void Delete(Guid id);
    }
}
