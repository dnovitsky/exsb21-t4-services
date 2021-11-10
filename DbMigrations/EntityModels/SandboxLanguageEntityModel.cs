using DbMigrations.EntityModels.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class SandboxLanguageEntityModel : IdEntityModel
    {
        [Required]
        public Guid SandboxId { get; set; }
        public SandboxEntityModel Sandbox { get; set; }

        [Required]
        public Guid LanguageId { get; set; }
        public LanguageEntityModel Language { get; set; }
    }
}
