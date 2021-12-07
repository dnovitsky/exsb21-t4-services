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

        public TestTaskRouteService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> GetDownloadUrl(string candidateToken)
        {
            string serverUrl = (await unitOfWork.AppSettings.FindByConditionAsync(x => x.Name == "TestTaskUrl")).FirstOrDefault().Value;
            string downloadUrl = serverUrl + "/" + candidateToken;
            return downloadUrl;
        }

        public async Task<string> GetUploadPageUrl(string candidateToken)
        {
            string serverUrl = (await unitOfWork.AppSettings.FindByConditionAsync(x => x.Name == "TestResultUrl")).FirstOrDefault().Value;
            string uploadPageUrl = serverUrl + "/" + candidateToken;
            return uploadPageUrl;
        }
    }
}
