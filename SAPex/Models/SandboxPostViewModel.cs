using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAPex.Models
{
    public class SandboxPostViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int MaxCandidates { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime StartRegistration { get; set; }

        public DateTime EndRegistration { get; set; }

        public string Status { get; set; }

        public IEnumerable<Guid> StackTechnologyIds { get; set; }

        public IEnumerable<Guid> LanguageIds { get; set; }

        public IEnumerable<Guid> MentorIds { get; set; }

        public IEnumerable<Guid> RecruiterIds { get; set; }

        public IEnumerable<Guid> InterviewersIds { get; set; }
    }
}
