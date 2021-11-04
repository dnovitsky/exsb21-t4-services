using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAPex.Models
{
    public class CreateCondidateViewModel
    {
        [Required]
        public Guid SandboxId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Surname { get; set; }

        [Required]
        public Guid LanguageLevelId { get; set; }

        public Guid Language { get; set; } = Guid.NewGuid(); // set English as default language

        [Required]
        public Guid PrimaryTechnology { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string Skype { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Location { get; set; }

        public string Motivation { get; set; }

        public string CurrentJob { get; set; }

        public string AvailabilityHoursPerDay { get; set; }

        public string BestTimeToContactToCandidate { get; set; }

        [Required]
        public bool IsPlaningToJoinExadel { get; set; }

        [Required]
        public bool IsProvidePersonalData { get; set; }

        public List<string> ProfessionaCertificates { get; set; }

        public List<string> AdditionSkills { get; set; }
    }
}
