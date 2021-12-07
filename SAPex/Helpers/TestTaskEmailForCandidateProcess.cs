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
        private readonly ITestTaskRouteService _testTaskRouteService;

        public TestTaskEmailForCandidateProcess(IUnitOfWork unitOfWork,
            ICandidateProcessTestTaskService candidateProcessTestTaskService,
            ITestTaskTokenBusinessService testTaskTokenService,
            ITestTaskRouteService testTaskRouteService)
        {
            _unitOfWork = unitOfWork;
            _candidateProcessTestTaskService = candidateProcessTestTaskService;
            _testTaskTokenService = testTaskTokenService;
            _testTaskRouteService = testTaskRouteService;
        }

        public async Task<bool> SendTestTaskEmailForCandidate(IList<Guid> processIds)
        {
            try
            {
                foreach (var processId in processIds)
                {
                    var candidateTestTaskEmailData = await GenerateCandidateTestTaskEmailData(processId);

                    // call email service
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async Task<TestTaskEmailCandidateModel> GenerateCandidateTestTaskEmailData(Guid processId)
        {
            try
            {
                DateTime endTestDate = DateTime.UtcNow.AddDays(2);

                var candidateProcess = await _unitOfWork.CandidateProcceses.FindByIdAsync(processId);
                var candidateSandbox = candidateProcess.CandidateSandbox;
                var candidateProcessTestTask = await GetCandidateProcessTestTask(candidateProcess, endTestDate);
                var token = candidateProcessTestTask.Token;

                return new TestTaskEmailCandidateModel()
                {
                    Name = candidateSandbox.Candidate.Name + " " + candidateSandbox.Candidate.Surname,
                    SandboxName = candidateSandbox.Sandbox.Name,
                    DownloadUrl = await _testTaskRouteService.GetDownloadUrl(token),
                    UploadPageUrl = await _testTaskRouteService.GetUploadPageUrl(token),
                    EndTime = (candidateProcessTestTask.SendTestDate - endTestDate).TotalHours.ToString(),
                };
            }
            catch
            {
                return null;
            }
        }

        private async Task<CandidateProcessTestTaskDtoModel> GetCandidateProcessTestTask(CandidateProcesEntityModel candidateProcess, DateTime endTestDate)
        {
            try
            {
                List<FileEntityModel> files = (List<FileEntityModel>)await _unitOfWork.Files.GetAllAsync();
                var file = files.Count > 0 ? files[0] : null;
                var email = candidateProcess.CandidateSandbox.Candidate.Email;
                var token = _testTaskTokenService.GetToken(email);

                var candidateProcessTestTask = await _candidateProcessTestTaskService.CreateCandidateProcessTestTaskAsync(new CandidateProcessTestTaskDtoModel(
                    candidateProcess.Id,
                    file.Id,
                    endTestDate,
                    token));

                return candidateProcessTestTask;
            }
            catch
            {
                return null;
            }
        }
    }
}
