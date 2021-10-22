using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class CandidateTechSkill
    {
        public int Id { get; set; }
        public List<Skill> SkillId { get; set; }
        public List<Candidate> CandidateId { get; set; }
        
    }
}
