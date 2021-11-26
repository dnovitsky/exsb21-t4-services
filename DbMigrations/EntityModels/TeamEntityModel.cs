using DbMigrations.EntityModels.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class TeamEntityModel : NameEntityModel
    {
        public TeamEntityModel() : base()
        {
            UserTeams = new List<UserTeamEntityModel>();
        }

        [Required]
        public Guid SandboxId { get; set; }
        public virtual SandboxEntityModel Sandbox { get; set; }
        public virtual IList<UserTeamEntityModel> UserTeams { get; set; }
        //public CandidateSandboxEntityModel CandidateSandbox { get; set; }
    }
}
