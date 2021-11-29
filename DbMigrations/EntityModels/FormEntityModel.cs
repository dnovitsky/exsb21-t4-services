using DbMigrations.EntityModels.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class FormEntityModel : NameEntityModel
    {
        public FormEntityModel() : base()
        {
            AccessForms = new List<AccessFormEntityModel>();
        }

        public virtual IList<AccessFormEntityModel> AccessForms { get; set; }

    }
}
