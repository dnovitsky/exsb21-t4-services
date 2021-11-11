using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DbMigrations.EntityModels
{
    public class UserSandBoxEntityModel
    {
        public UserSandBoxEntityModel()
        {
            UserTeams = new List<UserTeamEntityModel>();
        }
        [Key]
        public Guid Id { get; set; }

        public Guid SandBoxId { get; set; }
        public virtual SandboxEntityModel Sandbox {get;set;}
        public Guid UserId { get; set; }
        public virtual UserEntityModel User { get; set; }

        public string FunctionalRole { get; set; }

        public virtual IList<UserTeamEntityModel> UserTeams { get; set; }
    }
}
