using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class Rating
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        public List<Skill> SkillId { get; set; }
    }
}
