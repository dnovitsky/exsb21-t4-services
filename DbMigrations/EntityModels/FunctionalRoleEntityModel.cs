using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class FunctionalRoleEntityModel
    {
        public FunctionalRoleEntityModel()
        {
            UserRoles = new List<UserFunctionalRoleEntityModel>();
            AccessForms = new List<AccessFormEntityModel>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public IList<UserFunctionalRoleEntityModel> UserRoles { get; set; }
        public IList<AccessFormEntityModel> AccessForms { get; set; }
    }
}
