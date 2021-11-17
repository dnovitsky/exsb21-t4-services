using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class RatingDtoModel
    {
        public Guid Id { get; set; }

        public int Mark { get; set; }

        public Guid SkillId { get; set; }
        public virtual SkillDtoModel Skill { get; set; }
    }
}
