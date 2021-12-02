using DbMigrations.EntityModels.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class UserCandidateSandboxEntityModel : IdEntityModel
    {
        [Required]
        public Guid UserId { get; set; }
        public virtual UserEntityModel User { get; set; }

        [Required]
        public Guid CandidateSandboxId { get; set; }
        public virtual CandidateSandboxEntityModel CandidateSandbox { get; set; }
    }
}
