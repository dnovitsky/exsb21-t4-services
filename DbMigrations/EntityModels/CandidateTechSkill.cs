using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class CandidateTechSkill
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public List<Skill> Skills { get; set; }
        [Required]
        public List<Candidate> Candidates { get; set; }
        
    }
}
