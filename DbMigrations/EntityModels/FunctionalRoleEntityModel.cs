using DbMigrations.EntityModels.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class FunctionalRoleEntityModel : NameEntityModel
    {
        public FunctionalRoleEntityModel() : base()
        {
            UserRoles = new List<UserFunctionalRoleEntityModel>();
            AccessForms = new List<AccessFormEntityModel>();
        }

        public virtual IList<UserFunctionalRoleEntityModel> UserRoles { get; set; }
        public virtual IList<AccessFormEntityModel> AccessForms { get; set; }
    }
}
