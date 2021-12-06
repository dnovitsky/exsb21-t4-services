using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ITestTaskRouteService
    {
        Task<string> GetDownloadUrl(Guid candidateId);
        Task<string> GetUploadPageUrl(Guid candidateId);
        Task<string> GetTestTaskLifeTime();
    }
}
