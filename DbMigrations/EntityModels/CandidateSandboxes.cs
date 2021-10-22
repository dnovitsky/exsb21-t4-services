using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.Models
{
    public class CandidateSandboxes
    {
        public int Id { get; set; }
        public CandidatesProcces CandidateProccesId { get; set; }
        public ProjectRole ProjectRoleId { get; set; }
        public Team TeamId { get; set; }
    }
}
