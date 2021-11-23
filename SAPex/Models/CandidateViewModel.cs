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

        public dynamic Location { get; set; }

        public string Skype { get; set; }

        public string Phone { get; set; }

        public string CurrentJob { get; set; }

        public string ProfessionaCertificates { get; set; }

        public string AdditionalSkills { get; set; }

        public IList<dynamic> CandidateLanguages { get; set; }

        public IList<dynamic> CandidateTechSkills { get; set; }

        public IList<dynamic> CandidateSandboxes { get; set; }
    }
}
