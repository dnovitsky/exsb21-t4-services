using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ITestTaskRouteService
    {
        Task<string> GetDownloadUrl(string token);
        Task<string> GetUploadPageUrl(string token);
    }
}
