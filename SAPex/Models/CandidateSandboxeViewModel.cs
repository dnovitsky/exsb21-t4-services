using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAPex.Models
{
    public class CandidateSandboxeViewModel
    {
        public Guid Id { get; set; }

        public SandboxViewModel Sandbox { get; set; }

        public string CurrentJob { get; set; }

        public IEnumerable<CandidateProcessViewModel> CandidateProcesses { get; set; }

        public CandidateProjectRoleViewModel? CandidateProjectRole { get; set; }
    }
}
