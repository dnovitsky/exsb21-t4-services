using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAPex.Models
{
    public class CreateCandidateViewModel
    {
        [Required]
        public Guid SandboxId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Surname { get; set; }

        [Required]
        public Guid EnglishLevelId { get; set; }

        [Required]
        public Guid LanguageId { get; set; }

        [Required]
        public Guid PrimaryTechnologyId { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Skype { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Location { get; set; }

        public string Motivation { get; set; }

        public string CurrentJob { get; set; }

        public string AvailabillityPerDay { get; set; }

        public string TimeContact { get; set; }

        [Required]
        public bool IsJoinToExadel { get; set; }

        [Required]
        public bool IsAgreement { get; set; }

        public string ProfessionaCertificates { get; set; }

        public string AdditionalSkills { get; set; }
    }
}
