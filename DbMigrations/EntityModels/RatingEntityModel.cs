using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class RatingEntityModel
    {
        public RatingEntityModel()
        {
            Feedbacks = new List<FeedbackEntityModel>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int Mark { get; set; }
        [Required]
        public Guid SkillId { get; set; }
        public virtual SkillEntityModel Skill { get; set; }

        public virtual IList<FeedbackEntityModel> Feedbacks  { get; set; }
    }
}
