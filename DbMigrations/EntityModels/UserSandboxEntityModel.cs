using System;
using System.Collections.Generic;
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
        public SandboxEntityModel Sandbox {get;set;}
        public Guid UserRoleId { get; set; }
        public UserRoleEntityModel UserRole { get; set; }
        public Guid UserId { get; set; }
        public UserEntityModel User { get; set; }

        public IList<UserTeamEntityModel> UserTeams { get; set; }
    }
}
