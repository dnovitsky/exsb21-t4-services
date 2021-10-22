using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class CandidateSandbox
    {
        public int Id { get; set; }
        public List<Sandbox> SandboxId { get; set; }
        public CandidatesProcces CandidateProccesId { get; set; }
        public List<ProjectRole> ProjectRoleId { get; set; }
        public Team TeamId { get; set; }
    }
}
