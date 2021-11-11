using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class TeamEntityModel
    {
        public TeamEntityModel()
        {
            UserTeams = new List<UserTeamEntityModel>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public Guid SandboxId { get; set; }
        public virtual SandboxEntityModel Sandbox { get; set; }
        public virtual IList<UserTeamEntityModel> UserTeams { get; set; }
        
    }
}
