using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class RatingViewModel: AbstractIdViewModel
    {
        public RatingViewModel() : base()
        {
            this.mark = 0;
            this.skillId = Guid.NewGuid();
        }
        public RatingViewModel(int mark, Guid skillId) : base() {
            this.mark = mark;
            this.skillId = skillId;
        }
        [Required]
        public int mark { get; set; }
        [Required]
        public Guid skillId { get; set; }
    }
}
