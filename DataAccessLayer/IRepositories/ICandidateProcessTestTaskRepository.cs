using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface ICandidateProcessTestTaskRepository
    {
        Task<IEnumerable<CandidateProcessTestTaskEntityModel>> GetAllAsync();
        Task<IEnumerable<CandidateProcessTestTaskEntityModel>> FindByConditionAsync(Expression<Func<CandidateProcessTestTaskEntityModel, bool>> expression);
        Task<CandidateProcessTestTaskEntityModel> FindByIdAsync(Guid id);

        Task<CandidateProcessTestTaskEntityModel> CreateAsync(CandidateProcessTestTaskEntityModel item);

        void Update(CandidateProcessTestTaskEntityModel item);
        void Delete(Guid id);
    }
}
