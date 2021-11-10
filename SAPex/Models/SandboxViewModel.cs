using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAPex.Models
{
    public class SandboxViewModel
    {
        [DefaultValue(null)]
        public Guid? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int MaxCandidates { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime StartRegistration { get; set; }

        [Required]
        public DateTime EndRegistration { get; set; }
    }
}
