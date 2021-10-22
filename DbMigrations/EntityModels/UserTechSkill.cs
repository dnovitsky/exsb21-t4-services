using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DbMigrations.EntityModels
{
    public class UserTechSkill
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public List<User> UserId { get; set; }
        [Required]
        public List<Skill> SkillId { get; set; }
    }
}
