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
        protected readonly CandidateProfile profile;
        private readonly IUnitOfWork unitOfWork;

        public CandidateService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> AddCandidateAsync(CandidateDtoModel candidateDto)
        {
            try
            {
                CandidateEntityModel candidateEM = profile.mapToEM(candidateDto);
                await Task.Run(() => unitOfWork.Candidates.CreateAsync(candidateEM));
                unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void DeleteCandidate(int id)
        {
            unitOfWork.Languages.Delete(id);
        }

        public async Task<CandidateDtoModel> FindCandidateByIdAsync(int id)
        {
            CandidateEntityModel candidateEM = await unitOfWork.Candidates.FindByIdAsync(id);
            CandidateDtoModel candidateDto = profile.mapToDto(candidateEM);
            return candidateDto;
        }

        public async Task<IEnumerable<CandidateDtoModel>> FindCandidateAsync(Expression<Func<CandidateEntityModel, bool>> expression)
        {
            IEnumerable<CandidateEntityModel> candidateEM = await unitOfWork.Candidates.FindByConditionAsync(expression);
            return profile.mapListToDto(candidateEM);
        }

        public async Task<IEnumerable<CandidateDtoModel>> GetAllCandidateAsync()
        {
            IEnumerable<CandidateEntityModel> candidateEM = await Task.Run(() => unitOfWork.Candidates.GetAllAsync());
            return profile.mapListToDto(candidateEM);
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

        Task<CandidateDtoModel> ICandidateService.FindCandidateByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
