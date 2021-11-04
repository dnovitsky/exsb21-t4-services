using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAPex.Models
{
    public class UpdateCondidateViewModel
    {
        [DefaultValue(null)]
        public List<SanboxViewModel>? Sandboxes { get; set; }

        [DefaultValue(null)]
        public Guid? StatusId { get; set; }

        [DefaultValue(null)]
        public string? Name { get; set; }

        [DefaultValue(null)]
        public string? Surname { get; set; }

        [DefaultValue(null)]
        public Guid? LanguageId { get; set; }

        [DefaultValue(null)]
        public Guid? PrimaryTechnology { get; set; }

        [DefaultValue(null)]
        public Guid? LanguageLevelId { get; set; }

        [DefaultValue(null)]
        [Phone]
        public string? PhoneNumber { get; set; }

        [DefaultValue(null)]
        public string? Skype { get; set; }

        [DefaultValue(null)]
        [EmailAddress]
        public string? Email { get; set; }

        [DefaultValue(null)]
        public string? Location { get; set; }

        [DefaultValue(null)]
        public string? Motivation { get; set; }

        [DefaultValue(null)]
        public string? CurrentJob { get; set; }

        [DefaultValue(null)]
        [Timestamp]
        public string? AvailabilityHoursPerDay { get; set; }

        [DefaultValue(null)]
        [Timestamp]
        public string? BestTimeToContactToCandidate { get; set; }

        [DefaultValue(null)]
        public bool? IsPlaningToJoinExadel { get; set; }

        [DefaultValue(null)]
        public bool? IsProvidePersonalData { get; set; }

        [DefaultValue(null)]
        public List<string>? ProfessionaCertificates { get; set; }

        [DefaultValue(null)]
        public List<string>? AdditionSkills { get; set; }
    }
}
