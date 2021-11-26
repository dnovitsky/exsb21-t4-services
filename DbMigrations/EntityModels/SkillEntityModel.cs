using DbMigrations.EntityModels.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class SkillEntityModel : NameEntityModel
    {
        public SkillEntityModel() : base()
        {
            UserTechSkills = new List<UserTechSkillEntityModel>();
            CandidateTechSkills = new List<CandidateTechSkillEntityModel>();
        }

        public virtual IList<UserTechSkillEntityModel> UserTechSkills { get; set; }
        public virtual IList<CandidateTechSkillEntityModel> CandidateTechSkills { get; set; }
    }
}
