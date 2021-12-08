using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class EmailBodyBuilderModel
    {
        public string Name { get; set; }

        public string SandboxName{ get; set; }

        public string TestTaskDownloadUrl { get; set; }

        public string TestTaskUploadUrl { get; set; }

        public string TestTaskLifeTime { get; set; }
    }
}
