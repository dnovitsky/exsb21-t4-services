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
        Task<PagedList<CandidateDtoModel>> GetPagedSandboxesAsync(InputParametrsDtoModel parametrs, FilterParametrsDtoModel filterParametrs);
        void UpdateCandidate(CandidateDtoModel candidateDto);
        Task<CandidateDtoModel> FindCandidateByIdAsync(Guid id);
        void DeleteCandidate(Guid id);
    }
}
