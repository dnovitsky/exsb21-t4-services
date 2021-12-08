using DbMigrations.EntityModels.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class AppSettingEntityModel : NameEntityModel
    {
        [Required]
        public string Value { get; set; }
    }
}
