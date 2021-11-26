using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class CandidateProjectRoleViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
