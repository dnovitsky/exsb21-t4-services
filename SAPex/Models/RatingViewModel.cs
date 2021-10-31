using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class RatingViewModel: AbstractIdViewModel
    {
        public RatingViewModel(Guid id, int mark, Guid skillId) : base(id) {
            this.mark = mark;
            this.skillId = skillId;
        }
        [Required]
        public int mark { get; set; }
        [Required]
        public Guid skillId { get; set; }
    }
}
