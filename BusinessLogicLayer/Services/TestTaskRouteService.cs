using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class TestTaskRouteService : ITestTaskRouteService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICandidateProcessTestTaskService candidateProcessTestTaskService;

        public TestTaskRouteService(IUnitOfWork unitOfWork, ICandidateProcessTestTaskService candidateProcessTestTaskService)
        {
            this.unitOfWork = unitOfWork;
            this.candidateProcessTestTaskService = candidateProcessTestTaskService;
        }

        public async Task<string> GetDownloadUrl(Guid candidateId)
        {
            string serverUrl = (await unitOfWork.AppSettings.FindByConditionAsync(x => x.Name == "TestTaskUrl")).FirstOrDefault().Value;
            string candidateToken = (await candidateProcessTestTaskService.GetCandidateProcessTestTaskByIdAsync(candidateId)).LinkDownloadToken;
            string downloadUrl = serverUrl +"/"+ candidateToken;
            return downloadUrl;
        }

        public async Task<string> GetTestTaskLifeTime()
        {
            return (await unitOfWork.AppSettings.FindByConditionAsync(x => x.Name == "TestTaskLifeTime")).FirstOrDefault().Value;
        }

        public async Task<string> GetUploadPageUrl(Guid candidateId)
        {
            string serverUrl = (await unitOfWork.AppSettings.FindByConditionAsync(x => x.Name == "TestResultUrl")).FirstOrDefault().Value;
            string candidateToken = (await candidateProcessTestTaskService.GetCandidateProcessTestTaskByIdAsync(candidateId)).LinkDownloadToken;
            string uploadPageUrl = serverUrl +"/"+ candidateToken;
            return uploadPageUrl;
        }
    }
}
