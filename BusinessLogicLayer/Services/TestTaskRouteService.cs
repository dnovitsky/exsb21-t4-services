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
        private TestTaskRoutModel _testTaskRoutModel;

        public TestTaskRouteService() { }

        public void Init(TestTaskRoutModel testTaskRoutModel)
        {
            _testTaskRoutModel = testTaskRoutModel;
        }

        public async Task<string> GetDownloadUrl()
        {
            return await TemplateHelper.GenerateDownloadLink(_testTaskRoutModel);
        }
        public async Task<string> GetUploadPageUrl()
        {
            return await TemplateHelper.GenerateUpDownloadLink(_testTaskRoutModel);
        }
    }
}
