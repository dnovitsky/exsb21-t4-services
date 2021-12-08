using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class CandidateSandboxDtoModel
    {
        public Guid Id { get; set; }

        public string Motivation { get; set; }

        public string CurrentJob { get; set; }

        public string TimeContact { get; set; }

        public bool IsJoinToExadel { get; set; }

        public bool IsAgreement { get; set; }

        public StackTechnologyDtoModel PrimaryTechnology { get; set; }

        public SandboxDtoModel Sandbox { get; set; }

        public IEnumerable<CandidateProcessDtoModel> CandidateProcesses { get; set; }

        public CandidateProjectRoleDtoModel? CandidateProjectRole { get; set; }
    }
}
