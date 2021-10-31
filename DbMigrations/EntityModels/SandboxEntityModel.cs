using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class SandboxEntityModel
    {
        public SandboxEntityModel()
        {
            UserSandboxes = new List<UserSandBoxEntityModel>();
            CandidateSandboxes = new List<CandidateSandboxEntityModel>();
            Teams = new List<TeamEntityModel>();
            SandboxStackTechnologies = new List<SandboxStackTechnologyEntityModel>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int MaxCandidates { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public DateTime StartRegistration { get; set; }
        [Required]
        public DateTime EndRegistration { get; set; }

        
        public IList<UserSandBoxEntityModel> UserSandboxes  { get; set; }
        public IList<CandidateSandboxEntityModel> CandidateSandboxes  { get; set; }
        public IList<TeamEntityModel> Teams { get; set; }
        public IList<SandboxStackTechnologyEntityModel> SandboxStackTechnologies { get; set; }

    }
}
