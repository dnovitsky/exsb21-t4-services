using BusinessLogicLayer.Helpers;
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
        private TestTaskRoutModel _model;

        public TestTaskRouteService() { }

        public void Init(TestTaskRoutModel testTaskRoutModel)
        {
            _model = testTaskRoutModel;
        }

        public async Task<string> GetDownloadUrl()
        {
            return $"{_model.DownloadUrl}{_model.Token}";
        }
        public async Task<string> GetUploadPageUrl()
        {
            return $"{_model.UploadUrl}{_model.Token}";
        }
    }
}
