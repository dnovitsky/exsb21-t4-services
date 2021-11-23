using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class SkillEntityModel
    {
        public SkillEntityModel()
        {
            UserTechSkills = new List<UserTechSkillEntityModel>();
            CandidateTechSkills = new List<CandidateTechSkillEntityModel>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual IList<UserTechSkillEntityModel> UserTechSkills { get; set; }
        public virtual IList<CandidateTechSkillEntityModel> CandidateTechSkills { get; set; }
    }
}
