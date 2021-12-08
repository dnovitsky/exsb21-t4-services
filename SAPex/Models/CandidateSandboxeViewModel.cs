using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAPex.Models
{
    public class CandidateSandboxeViewModel
    {
        public Guid Id { get; set; }

        public string Motivation { get; set; }

        public string CurrentJob { get; set; }

        public string TimeContact { get; set; }

        public bool IsJoinToExadel { get; set; }

        public bool IsAgreement { get; set; }

        public StackTechnologyViewModel PrimaryTechnology { get; set; }

        public SandboxViewModel Sandbox { get; set; }

        public IEnumerable<CandidateProcessViewModel> CandidateProcesses { get; set; }

        public CandidateProjectRoleViewModel? CandidateProjectRole { get; set; }
    }
}
