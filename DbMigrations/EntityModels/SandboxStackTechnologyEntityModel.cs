using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class SandboxStackTechnologyEntityModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid SandboxId { get; set; }
        public virtual SandboxEntityModel Sandbox { get; set; }

        [Required]
        public Guid StackTechnologyId { get; set; }
        public virtual StackTechnologyEntityModel StackTechnology { get; set; }
    }
}
