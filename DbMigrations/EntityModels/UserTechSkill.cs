using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DbMigrations.Models
{
    public class UserTechSkill
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public User UserId { get; set; }
        [Required]
        public Skill SkillId { get; set; }
    }
}
