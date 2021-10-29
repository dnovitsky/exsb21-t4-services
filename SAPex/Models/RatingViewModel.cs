using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class RatingViewModel: AbstractIdViewModel
    {
        public RatingViewModel(Guid Id, int Mark, Guid SkillId) : base(Id) {
            this.Mark = Mark;
            this.SkillId = SkillId;
        }
        [Required]
        public int Mark { get; set; }
        [Required]
        public Guid SkillId { get; set; }
    }
}
