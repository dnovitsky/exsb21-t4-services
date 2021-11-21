using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CandidateService : ICandidateService
    {
        protected readonly CandidateProfile profile = new CandidateProfile();
        private readonly IUnitOfWork unitOfWork;

        public CandidateService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> AddCandidateAsync(CreateCandidateDtoModel candidateDto)
        {
            try
            {
                var candidate = await unitOfWork.Candidates.CreateAsync(profile.mapNewCandidateToEM(candidateDto));

                if (candidate != null)
                {
                    var candidateProcess = await unitOfWork.CandidateProcceses.CreateAsync(profile.mapNewCandidateProcessEM(candidateDto));
                    var candidateSandBoxe = await unitOfWork.CandidateSandboxes.CreateAsync(profile.mapNewCandidateSandBoxToEM(candidate.Id, candidateDto, candidateProcess));
                    var candidateLanguage = await unitOfWork.CandidateLanguages.CreateAsync(profile.mapNewCandidateLanguagesEM(candidate.Id, candidateDto));

                    await unitOfWork.SaveAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void DeleteCandidate(Guid id)
        {
            unitOfWork.Languages.Delete(id);
        }

        public async Task<CandidateDtoModel> FindCandidateByIdAsync(Guid id)
        {
            CandidateEntityModel candidateEM = await unitOfWork.Candidates.FindByIdAsync(id);
            CandidateDtoModel candidateDto = profile.mapCandidateEMToCandidateDto(candidateEM);
            return candidateDto;
        }

        public async Task<IEnumerable<CandidateDtoModel>> FindCandidateAsync(Expression<Func<CandidateEntityModel, bool>> expression)
        {
            IEnumerable<CandidateEntityModel> candidateEM = await unitOfWork.Candidates.FindByConditionAsync(expression);
            return profile.mapCandidateEMListToCandidateDtoList(candidateEM);
        }

        public async Task<IEnumerable<CandidateDtoModel>> GetAllCandidateAsync()
        {
            IEnumerable<CandidateEntityModel> candidateEM = await unitOfWork.Candidates.GetAllAsync();

            return profile.mapCandidateEMListToCandidateDtoList(candidateEM);
        }

        public void UpdateCandidate(CandidateDtoModel candidateDto)
        {
            CandidateEntityModel candidateEM = profile.mapToEM(candidateDto);
            unitOfWork.Candidates.Update(candidateEM);
            unitOfWork.SaveAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
