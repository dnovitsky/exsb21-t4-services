using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DbMigrations.EntityModels
{
    public class UserTechSkillEntityModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public virtual UserEntityModel User { get; set; }
        [Required]
        public Guid SkillId { get; set; }
        public virtual SkillEntityModel Skill { get; set; }
    }
}
