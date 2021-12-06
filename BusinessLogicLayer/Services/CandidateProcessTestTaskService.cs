using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CandidateProcessTestTaskService : ICandidateProcessTestTaskService
    {
        private readonly IUnitOfWork unitOfWork;
        protected readonly CandidateProccessTestTasksProfile profile;

        public CandidateProcessTestTaskService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.profile = new CandidateProccessTestTasksProfile();
        }

        public async Task<CandidateProccessTestTaskDtoModel> CreateCandidateProcessTestTaskAsync(CandidateProccessTestTaskDtoModel candidateProccessTestTaskDM)
        {
            var candidateProccessTestTaskEM = await unitOfWork.CandidateProccessTestTasks.CreateAsync( new CandidateProccessTestTaskEntityModel()
            {
                CandidateProcessId = candidateProccessTestTaskDM.CandidateProcessId,
                TestFileId = candidateProccessTestTaskDM.TestFileId,
                EndTestDate = candidateProccessTestTaskDM.EndTestDate,
                LinkDownloadToken = candidateProccessTestTaskDM.LinkDownloadToken
            });
            await unitOfWork.SaveAsync();

            return profile.mapToDto(candidateProccessTestTaskEM);
        }

        public async Task<string> AddCandidateResponseTestFileAsync(Guid candidateProccessTestTaskId, Guid candidateResponseTestFileId, string email)
        {
            try
            {
                var candidateProccessTestTaskEM = await unitOfWork.CandidateProccessTestTasks.FindByIdAsync(candidateProccessTestTaskId);
                
                if(isValid(email))
                {
                    candidateProccessTestTaskEM.CandidateResponseTestFileId = candidateResponseTestFileId;
                    await unitOfWork.SaveAsync();

                    return "Added";
                }

                return candidateProccessTestTaskEM == null ? "User dosn't exist" : "Not Valid";

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public async Task<CandidateProccessTestTaskDtoModel> GetCandidateProcessTestTaskByIdAsync(Guid candidateProccessTestTaskId)
        {
            var candidateProccessTestTaskEM = await unitOfWork.CandidateProccessTestTasks.FindByIdAsync(candidateProccessTestTaskId);
            return profile.mapToDto(candidateProccessTestTaskEM);
        }

        public async Task<IEnumerable<CandidateProccessTestTaskDtoModel>> GetCandidateProcessTestTasksAsync()
        {
            var candidateProccessTestTasksEM = await unitOfWork.CandidateProccessTestTasks.GetAllAsync();
            return profile.mapListToDto(candidateProccessTestTasksEM);
        }

        public async Task<CandidateProccessTestTaskDtoModel> UpdateCandidateProcessTestTaskAsync(Guid candidateProccessTestTaskId, UpdateCandidateProccessTestTaskDtoModel updateCandidateProccessTestTaskDM)
        {
            var isUpdated = false;
            var candidateProccessTestTaskEM = await unitOfWork.CandidateProccessTestTasks.FindByIdAsync(candidateProccessTestTaskId);

            if(updateCandidateProccessTestTaskDM.TestFileId != null)
            {
                candidateProccessTestTaskEM.TestFileId = (Guid)updateCandidateProccessTestTaskDM.TestFileId;
                isUpdated = true;
            }
            if (updateCandidateProccessTestTaskDM.EndTestDate != null)
            {
                candidateProccessTestTaskEM.EndTestDate = (DateTime)updateCandidateProccessTestTaskDM.EndTestDate;
                isUpdated = true;
            }
            if (updateCandidateProccessTestTaskDM.CandidateResponseTestFileId != null)
            {
                candidateProccessTestTaskEM.CandidateResponseTestFileId = (Guid)updateCandidateProccessTestTaskDM.CandidateResponseTestFileId;
                isUpdated = true;
            }
            if (updateCandidateProccessTestTaskDM.LinkDownloadToken != "")
            {
                candidateProccessTestTaskEM.LinkDownloadToken = updateCandidateProccessTestTaskDM.LinkDownloadToken;
                isUpdated = true;
            }

            if(isUpdated)
            {
                unitOfWork.CandidateProccessTestTasks.Update(candidateProccessTestTaskEM);
                await unitOfWork.SaveAsync();
            }

            return profile.mapToDto(candidateProccessTestTaskEM);
        }

        public async Task<bool> DeleteCandidateProcessTestTaskAsync(Guid candidateProccessTestTaskId)
        {
            try
            {
                unitOfWork.CandidateProccessTestTasks.Delete(candidateProccessTestTaskId);
                await unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private bool isValid(string email)
        {
            return true;
        }
    }
}
