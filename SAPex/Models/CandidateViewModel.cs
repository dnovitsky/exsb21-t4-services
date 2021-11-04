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

        public string Email { get; set; }

        public string Location { get; set; }

        public string Skype { get; set; }

        public string Phone { get; set; }

        public string Education { get; set; }

        public IList<LanguageViewModel> CandidateLanguages { get; set; }

        public IList<SkillViewModel> CandidateTechSkills { get; set; }

        public IList<SanboxViewModel> CandidateSandboxes { get; set; }
    }
}
