using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DbMigrations.EntityModels
{
    public class UserRoleEntityModel
    {
        public UserRoleEntityModel()
        {
            UserSanboxes = new List<UserSandBoxEntityModel>();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid FunctionalRoleId { get; set; }
        public FunctionalRoleEntityModel FunctionalRole { get; set; }
        public Guid UserId { get; set; }
        public UserEntityModel User { get; set; }

        public IList<UserSandBoxEntityModel> UserSanboxes { get; set; }
    }
}
