using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;

namespace SAPex.Helpers
{
    public class TestTaskEmailForCandidateProcess
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICandidateProcessTestTaskService _candidateProcessTestTaskService;
        private readonly ITestTaskTokenBusinessService _testTaskTokenService;

        public TestTaskEmailForCandidateProcess(IUnitOfWork unitOfWork, ICandidateProcessTestTaskService candidateProcessTestTaskService, ITestTaskTokenBusinessService testTaskTokenService)
        {
            _unitOfWork = unitOfWork;
            _candidateProcessTestTaskService = candidateProcessTestTaskService;
            _testTaskTokenService = testTaskTokenService;
        }

        public async Task<string> GetCandidateProcessTestTaskToken(Guid processId, DateTime endTestDate)
        {
            try
            {
                var candidateProcess = await _unitOfWork.CandidateProcceses.FindByIdAsync(processId);
                List<FileEntityModel> files = (List<FileEntityModel>)await _unitOfWork.Files.GetAllAsync();
                var file = files.Count > 0 ? files[0] : null;
                var email = candidateProcess.CandidateSandbox.Candidate.Email;
                var token = _testTaskTokenService.GetToken(email);

                var candidateProcessTestTask = await _candidateProcessTestTaskService.CreateCandidateProcessTestTaskAsync(new CandidateProcessTestTaskDtoModel(
                    processId,
                    file.Id,
                    endTestDate,
                    token));

                return candidateProcessTestTask.Token;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IList<string>> GetCandidateProcessTestTaskTokens(IList<Guid> processIds, DateTime endTestDate)
        {
            try
            {
                var tokenList = new List<string>() { };

                foreach (var processId in processIds)
                {
                    var token = await GetCandidateProcessTestTaskToken(processId, endTestDate);
                    tokenList.Add(token);
                }

                return tokenList;
            }
            catch
            {
                return null;
            }
        }
    }
}
