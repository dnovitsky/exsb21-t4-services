using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class CandidateProjectRoleEntityModel
    {
        public CandidateProjectRoleEntityModel()
        {
            CandidateSandboxes = new List<CandidateSandboxEntityModel>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual IList<CandidateSandboxEntityModel> CandidateSandboxes { get; set; }
    }
}
