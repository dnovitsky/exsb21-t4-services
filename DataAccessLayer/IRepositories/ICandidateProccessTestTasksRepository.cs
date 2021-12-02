using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface ICandidateProccessTestTasksRepository
    {
        Task<IEnumerable<CandidateProccessTestTasksEntityModel>> GetAllAsync();
        Task<IEnumerable<CandidateProccessTestTasksEntityModel>> FindByConditionAsync(Expression<Func<CandidateProccessTestTasksEntityModel, bool>> expression);
        Task<CandidateProccessTestTasksEntityModel> FindByIdAsync(Guid id);

        Task<CandidateProccessTestTasksEntityModel> CreateAsync(CandidateProccessTestTasksEntityModel item);

        void Update(CandidateProccessTestTasksEntityModel item);
        void Delete(Guid id);
    }
}
