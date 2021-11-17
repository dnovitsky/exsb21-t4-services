using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class CandidateTechSkillEntityModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid SkillId { get; set; }
        public virtual SkillEntityModel Skill { get; set; }

        [Required]
        public Guid CandidateId { get; set; }
        public virtual CandidateEntityModel Candidate { get; set; }
    }
}
