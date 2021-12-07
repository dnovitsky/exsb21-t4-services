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

        public async Task<string> GetDownloadUrl(string token)
        {
            string serverUrl = (await unitOfWork.AppSettings.FindByConditionAsync(x => x.Name == "TestTaskUrl")).FirstOrDefault().Value;
            string downloadUrl = serverUrl +"/"+ token;
            string downloadUrl = serverUrl + candidateToken;
            return downloadUrl;
        }
        public async Task<string> GetUploadPageUrl(string token)
        public async Task<string> GetUploadPageUrl()
        {
            string uploadPageUrl = serverUrl +"?"+ token;
            string uploadPageUrl = serverUrl + candidateToken;
            return uploadPageUrl;
        }
    }
}
