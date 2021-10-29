using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class RatingViewModel: AbstractIdViewModel
    {
        [Required]
        public int Mark { get; set; }
        [Required]
        public Guid SkillId { get; set; }
    }
}
