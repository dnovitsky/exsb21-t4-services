using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<CandidateEntityModel>> GetAllAsync();
        Task<IEnumerable<CandidateEntityModel>> FindByConditionAsync(Expression<Func<CandidateEntityModel, bool>> expression);
        Task<CandidateEntityModel> FindByIdAsync(Guid id);
        Task<PagedList<CandidateEntityModel>> GetPagedAsync(InputParametrsDalModel parametrs, CandidateFilterParametrsDalModel candidateFilterParametrs);
        Task<CandidateEntityModel> CreateAsync(CandidateEntityModel item);

        IEnumerable<CandidateEntityModel> GetByUserId(Guid id);

        IEnumerable<CandidateEntityModel> GetByUserIdSandboxId(Guid userId, Guid sandboxId);

        void Update(CandidateEntityModel item);
        void Delete(Guid id);
    }
}
