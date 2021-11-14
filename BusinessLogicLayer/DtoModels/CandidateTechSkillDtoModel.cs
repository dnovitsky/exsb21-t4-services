using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class CandidateTechSkillDtoModel
    {
        public CandidateTechSkillDtoModel(Guid skillId)
        {
            Skill = new SkillDtoModel();
        }
        
        public Guid Id { get; set; }

        public SkillDtoModel Skill { get; set; }
    }
}
