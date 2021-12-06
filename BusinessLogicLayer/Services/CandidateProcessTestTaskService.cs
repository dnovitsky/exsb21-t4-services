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
                    Token = candidateProccessTestTaskDM.Token
                });
                await unitOfWork.SaveAsync();

                return profile.mapToDto(candidateProccessTestTaskEM);
            }

            return null;
        }

        public async Task<string> AddCandidateResponseTestFileAsync(Guid candidateProccessId, Guid candidateResponseTestFileId)
        {
            try
            {
                var candidateProccessTestTasksEM = await unitOfWork.CandidateProccessTestTasks.FindByConditionAsync(x => x.CandidateProcessId.Equals(candidateProccessId));
                var email = getEmailFromCandidateProccessTestTask(candidateProccessTestTasksEM.FirstOrDefault());

                foreach (var candidateProccessTestTaskEM in candidateProccessTestTasksEM)
                {
                    if (isValid(candidateProccessTestTaskEM, email))
                    {
                        candidateProccessTestTaskEM.CandidateResponseTestFileId = candidateResponseTestFileId;
                        await unitOfWork.SaveAsync();

                        return "Added candidate test file";
                    }
                }

                return "Data is invalid";

            }
            catch (Exception ex)
            {
                return "User does not exist";// ex.ToString();
            }
        }

        public async Task<IEnumerable<CandidateProcessTestTaskDtoModel>> GetCandidateProcessTestTasksByCandidateProcessIdAsync(Guid candidateProcessId)
        {
            var candidateProccessTestTasksEM = await unitOfWork.CandidateProccessTestTasks.FindByConditionAsync(x => x.CandidateProcessId.Equals(candidateProcessId));
            return profile.mapListToDto(candidateProccessTestTasksEM);
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
                var currentToken = candidateProccessTestTaskEM.Token;

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
                if (updateCandidateProccessTestTaskDM.Token != "" && testTaskTokenService.GetEmailByToken(currentToken).Equals(email))
                {
                    candidateProccessTestTaskEM.Token = updateCandidateProccessTestTaskDM.Token;
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

        public async Task<string> GenerateCandidateProcessTestTaskTokens(Guid processId, DateTime endTestDate)
        {
            try
            {
                var candidateProcess = await unitOfWork.CandidateProcceses.FindByIdAsync(processId);
                var fileEM = (await unitOfWork.Files.GetAllAsync()).FirstOrDefault();
                var email = candidateProcess.CandidateSandbox.Candidate.Email;
                var token = testTaskTokenService.GetToken(email);
                var candidateProcessTestTask = await this.CreateCandidateProcessTestTaskAsync( new CandidateProcessTestTaskDtoModel(
                    processId,
                    fileEM.Id,
                    endTestDate,
                    token
                ));

                return candidateProcessTestTask.Token;
            }
            catch
            {
                return null;
            }
        }

        private bool isValid(CandidateProcessTestTaskEntityModel candidateProccessTestTaskEM, string email)
        {
            var token = candidateProccessTestTaskEM.Token;

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
