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
        protected readonly CandidateProcessTestTasksProfile profile;
        private readonly TestTaskTokenBusinessService testTaskTokenService;

        public CandidateProcessTestTaskService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.profile = new CandidateProcessTestTasksProfile();
            this.testTaskTokenService = new TestTaskTokenBusinessService();
        }

        public async Task<CandidateProcessTestTaskDtoModel> CreateCandidateProcessTestTaskAsync(CandidateProcessTestTaskDtoModel candidateProccessTestTaskDM)
        {
            var candidateProcessId = candidateProccessTestTaskDM.CandidateProcessId;
            var candidateProcess = await unitOfWork.CandidateProcceses.FindByIdAsync(candidateProcessId);

            if (candidateProcess != null)
            {
                var email = candidateProcess.CandidateSandbox.Candidate.Email;
                var candidateProccessTestTaskEM = await unitOfWork.CandidateProccessTestTasks.CreateAsync(new CandidateProcessTestTaskEntityModel()
                {
                    CandidateProcessId = candidateProcessId,
                    TestFileId = candidateProccessTestTaskDM.TestFileId,
                    EndTestDate = candidateProccessTestTaskDM.EndTestDate.ToUniversalTime(),
                    LinkDownloadToken = testTaskTokenService.GetToken(email, candidateProcessId)
                });
                await unitOfWork.SaveAsync();

                return profile.mapToDto(candidateProccessTestTaskEM);
            }

            return null;
        }

        public async Task<string> AddCandidateResponseTestFileAsync(Guid candidateProccessTestTaskId, Guid candidateResponseTestFileId)
        {
            try
            {
                var candidateProccessTestTaskEM = await unitOfWork.CandidateProccessTestTasks.FindByIdAsync(candidateProccessTestTaskId);
                var email = getEmailFromCandidateProccessTestTask(candidateProccessTestTaskEM);

                if (isValid(candidateProccessTestTaskEM, email))
                {
                    candidateProccessTestTaskEM.CandidateResponseTestFileId = candidateResponseTestFileId;
                    await unitOfWork.SaveAsync();

                    return "Added candidate test file";
                }

                return "Data is invalid";

            }
            catch (Exception ex)
            {
                return "User does not exist";// ex.ToString();
            }
        }

        public async Task<CandidateProcessTestTaskDtoModel> GetCandidateProcessTestTaskByIdAsync(Guid candidateProccessTestTaskId)
        {
            var candidateProccessTestTaskEM = await unitOfWork.CandidateProccessTestTasks.FindByIdAsync(candidateProccessTestTaskId);
            return profile.mapToDto(candidateProccessTestTaskEM);
        }

        public async Task<IEnumerable<CandidateProcessTestTaskDtoModel>> GetCandidateProcessTestTasksAsync()
        {
            var candidateProccessTestTasksEM = await unitOfWork.CandidateProccessTestTasks.GetAllAsync();
            return profile.mapListToDto(candidateProccessTestTasksEM);
        }

        public async Task<string> UpdateCandidateProcessTestTaskAsync(Guid candidateProccessTestTaskId, UpdateCandidateProcessTestTaskDtoModel updateCandidateProccessTestTaskDM)
        {
            try
            {
                var isUpdated = false;
                var candidateProccessTestTaskEM = await unitOfWork.CandidateProccessTestTasks.FindByIdAsync(candidateProccessTestTaskId);
                var email = getEmailFromCandidateProccessTestTask(candidateProccessTestTaskEM);
                var currentToken = candidateProccessTestTaskEM.LinkDownloadToken;

                if (updateCandidateProccessTestTaskDM.TestFileId != null)
                {
                    candidateProccessTestTaskEM.TestFileId = (Guid)updateCandidateProccessTestTaskDM.TestFileId;
                    isUpdated = true;
                }
                if (updateCandidateProccessTestTaskDM.EndTestDate != null && DateTime.Now <= candidateProccessTestTaskEM.EndTestDate)
                {
                    candidateProccessTestTaskEM.EndTestDate = (DateTime)updateCandidateProccessTestTaskDM.EndTestDate;
                    isUpdated = true;
                }
                if (updateCandidateProccessTestTaskDM.CandidateResponseTestFileId != null && isValid(candidateProccessTestTaskEM, email))
                {
                    candidateProccessTestTaskEM.CandidateResponseTestFileId = (Guid)updateCandidateProccessTestTaskDM.CandidateResponseTestFileId;
                    isUpdated = true;
                }
                if (updateCandidateProccessTestTaskDM.LinkDownloadToken != "" && testTaskTokenService.GetEmailByToken(currentToken).Equals(email))
                {
                    candidateProccessTestTaskEM.LinkDownloadToken = updateCandidateProccessTestTaskDM.LinkDownloadToken;
                    isUpdated = true;
                }

                if (isUpdated)
                {
                    unitOfWork.CandidateProccessTestTasks.Update(candidateProccessTestTaskEM);
                    await unitOfWork.SaveAsync();

                    return "Updated data for candidate process test task";
                }

                return "Data is invalid";
            }
            catch (Exception ex)
            {
                return "User does not exist";
            }
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

        private bool isValid(CandidateProcessTestTaskEntityModel candidateProccessTestTaskEM, string email)
        {
            var token = candidateProccessTestTaskEM.LinkDownloadToken;

            return candidateProccessTestTaskEM.CandidateResponseTestFileId == null 
                && DateTime.UtcNow <= candidateProccessTestTaskEM.EndTestDate
                && testTaskTokenService.GetEmailByToken(token).Equals(email);
        }

        private string getEmailFromCandidateProccessTestTask(CandidateProcessTestTaskEntityModel candidateProccessTestTaskEM)
        {
            return candidateProccessTestTaskEM.СandidateProcess.CandidateSandbox.Candidate.Email;
        }
    }
}
