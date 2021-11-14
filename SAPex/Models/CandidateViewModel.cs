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

        public string Location { get; set; }

        public string Skype { get; set; }

        public string Phone { get; set; }

        public string Education { get; set; }

        public IList<dynamic> Languages { get; set; }

        public IList<dynamic> TechSkills { get; set; }

        public IList<CandidateSandboxeViewModel> CandidateSandboxes { get; set; }
    }
}
