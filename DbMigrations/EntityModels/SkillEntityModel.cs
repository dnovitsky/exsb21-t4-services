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
            SandBoxTechSkills = new List<SandBoxTechSkillEntityModel>();
            UserTechSkills = new List<UserTechSkillEntityModel>();
            Ratings = new List<RatingEntityModel>();
            CandidateTechSkills = new List<CandidateTechSkillEntityModel>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public IList<SandBoxTechSkillEntityModel> SandBoxTechSkills { get; set; }
        public IList<UserTechSkillEntityModel> UserTechSkills { get; set; }
        public IList<RatingEntityModel> Ratings { get; set; }
        public IList<CandidateTechSkillEntityModel> CandidateTechSkills { get; set; }
    }
}
