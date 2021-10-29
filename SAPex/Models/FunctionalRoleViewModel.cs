using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class FunctionalRoleViewModel: AbstractNameViewModel
    {
        [Required]
        public string Access { get; set; }
    }
}
