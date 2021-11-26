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

        public string CurrentJob { get; set; }

        public SandboxDtoModel Sandbox { get; set; }

        public IEnumerable<CandidateProcessDtoModel> CandidateProcesses { get; set; }

        public CandidateProjectRoleDtoModel? CandidateProjectRole { get; set; }

        // TeamId
        // public dynamic Team { get; set; }
    }
}
