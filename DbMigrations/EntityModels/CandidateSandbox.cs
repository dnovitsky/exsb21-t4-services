using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class CandidateSandbox
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public List<Sandbox> SandboxId { get; set; }
        [Required]
        public CandidatesProcces CandidateProccesId { get; set; }
        public List<ProjectRole> ProjectRoleId { get; set; }
        public Team TeamId { get; set; }
    }
}
