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
            Teams = new List<UserTeamEntityModel>();
        }
        [Key]
        public Guid Id { get; set; }

        public Guid SandBoxId { get; set; }
        public SandboxEntityModel Sandbox {get;set;}
        public Guid UserRoleId { get; set; }
        public UserRoleEntityModel UserRole { get; set; }
        public Guid UserId { get; set; }
        public UserEntityModel User { get; set; }

        public IList<UserTeamEntityModel> Teams { get; set; }
    }
}
