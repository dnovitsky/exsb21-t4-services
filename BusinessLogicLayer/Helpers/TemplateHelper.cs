using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Helpers
{
    public class TemplateHelper
    {
        public async static Task<string> GenerateName(CandidateEntityModel candidate)
        {
            return await Task.Run(() => candidate.Name + " " + candidate.Surname);
        }

        public async static Task<string> GenerateDownloadLink(TestTaskRoutModel testTaskRout)
        {
            return await Task.Run(() => testTaskRout.DownloadUrl + "/" + testTaskRout.Token);
        }

        public async static Task<string> GenerateUpDownloadLink(TestTaskRoutModel testTaskRout)
        {
            return await Task.Run(() => testTaskRout.UploadUrl + "?" + testTaskRout.Token);
        }
    }
}
