using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface ICandidateProccessTestTaskRepository
    {
        Task<IEnumerable<CandidateProccessTestTaskEntityModel>> GetAllAsync();
        Task<IEnumerable<CandidateProccessTestTaskEntityModel>> FindByConditionAsync(Expression<Func<CandidateProccessTestTaskEntityModel, bool>> expression);
        Task<CandidateProccessTestTaskEntityModel> FindByIdAsync(Guid id);

        Task<CandidateProccessTestTaskEntityModel> CreateAsync(CandidateProccessTestTaskEntityModel item);

        void Update(CandidateProccessTestTaskEntityModel item);
        void Delete(Guid id);
    }
}
