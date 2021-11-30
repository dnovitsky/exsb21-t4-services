using DbMigrations.EntityModels.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class CandidateProjectRoleEntityModel: NameEntityModel
    {
        public CandidateProjectRoleEntityModel() : base()
        {
            CandidateSandboxes = new List<CandidateSandboxEntityModel>();
        }

        public virtual IList<CandidateSandboxEntityModel> CandidateSandboxes { get; set; }
    }
}
