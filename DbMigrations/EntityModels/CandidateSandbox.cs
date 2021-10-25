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
        public List<Sandbox> Sandboxes { get; set; }
        public CandidatesProcces CandidateProcces { get; set; }
        public List<CandidateProjectRole> ProjectRoles { get; set; }
        public Team Team { get; set; }
    }
}
