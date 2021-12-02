using BusinessLogicLayer.DtoModels;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICandidateService
    {
        Task<CandidateDtoModel> AddCandidateAsync(CreateCandidateDtoModel candidateDto);
        Task<IEnumerable<CandidateDtoModel>> GetAllCandidateAsync();
        Task<IEnumerable<CandidateDtoModel>> FindCandidateAsync(Expression<Func<CandidateEntityModel, bool>> expression);
        Task<PagedList<CandidateDtoModel>> GetPagedCandidatesAsync(InputParametrsDtoModel parametrs, CandidateFilterParametrsDtoModel candidateFilterParametrs);
        Task<bool> UpdateCandidateStatus(Guid candidateId, Guid candidateSandboxId, Guid newStatusId);
        Task<CandidateDtoModel> FindCandidateByIdAsync(Guid id);
        Task<IEnumerable<CandidateDtoModel>> GetCandidatesByUserIdAsync(Guid id);
        Task<IEnumerable<CandidateDtoModel>> GetCandidatesByUserIdSandboxIdAsync(Guid userId, Guid sandboxId);
        void DeleteCandidate(Guid id);
    }
}
