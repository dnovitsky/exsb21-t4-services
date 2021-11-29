using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAPex.Models
{
    public class CandidateViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public LocationViewModel Location { get; set; }

        public string Skype { get; set; }

        public string Phone { get; set; }

        public string ProfessionaCertificates { get; set; }

        public string AdditionalSkills { get; set; }

        public IList<CandidateLanguagesViewModel> CandidateLanguages { get; set; }

        public IList<CandidateTechSkillsViewModel> CandidateTechSkills { get; set; }

        public IList<CandidateSandboxeViewModel> CandidateSandboxes { get; set; }
    }
}
