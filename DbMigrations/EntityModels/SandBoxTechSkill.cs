using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class SandBoxTechSkill
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public List<Skill> Candidates { get; set; }
        [Required]
        public List<Sandbox> Languages { get; set; }

    }
}
