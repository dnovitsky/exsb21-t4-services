using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class SandBoxTechSkill
    {
        public int Id { get; set; }

        public List<Skill> CandidateId { get; set; }

        public List<Sandbox> LanguageId { get; set; }

    }
}
