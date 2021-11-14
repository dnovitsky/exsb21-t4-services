using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class CandidateSandboxDtoModel
    {
        public CandidateSandboxDtoModel(Guid sandboxId)
        {
            Sandboxes = new SandboxDtoModel();

            CandidatesProcesses = new CandidateProcessDtoModel();

            ProjectRoles = new List<CandidateProcessDtoModel>() { new CandidateProcessDtoModel() };
        }

        public Guid Id { get; set; }

        public SandboxDtoModel Sandboxes { get; set; }

        public CandidateProcessDtoModel CandidatesProcesses { get; set; }

        public List<CandidateProcessDtoModel> ProjectRoles { get; set; } = new ();

        // TeamId
        public dynamic Team { get; set; }
    }
}
