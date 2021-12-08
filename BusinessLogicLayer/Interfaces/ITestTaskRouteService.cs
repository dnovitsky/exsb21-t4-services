using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ITestTaskRouteService
    {
        void Init(TestTaskRoutModel testTaskRoutModel);
        Task<string> GetDownloadUrl();
        Task<string> GetUploadPageUrl();
    }
}
