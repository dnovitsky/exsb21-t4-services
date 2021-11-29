using DbMigrations.EntityModels.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class StackTechnologyEntityModel : NameEntityModel
    {
        public StackTechnologyEntityModel() : base()
        {
            CandidateSandboxes = new List<CandidateSandboxEntityModel>();
            SandboxStackTechnologies = new List<SandboxStackTechnologyEntityModel>();
            UserStackTechnologies = new List<UserStackTechnologyEntityModel>();
        }

        public virtual IList<CandidateSandboxEntityModel> CandidateSandboxes { get; set; }
        public virtual IList<SandboxStackTechnologyEntityModel> SandboxStackTechnologies { get; set; }
        public virtual IList<UserStackTechnologyEntityModel> UserStackTechnologies { get; set; }
    }
}
