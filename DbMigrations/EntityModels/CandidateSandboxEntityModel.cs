using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class CandidateSandboxEntityModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid SandboxId { get; set; }
        public SandboxEntityModel Sandbox { get; set; }

        [Required]
        public Guid CandidateId { get; set; }
        public CandidateEntityModel Candidate { get; set; }

        [Required]
        public Guid CandidateProjectRoleId { get; set; }
        public CandidateProjectRoleEntityModel CandidateProjectRole { get; set; }

        [Required]
        public Guid TeamId { get; set; }
        public TeamEntityModel Team { get; set; }

        [Required]
        public Guid StackTechnologiesId { get; set; }
        public StackTechnologyEntityModel StackTechnologies { get; set; }

        [Required]
        public Guid CandidateProccesId { get; set; }
        public CandidateProccesEntityModel CandidateProcces { get; set; }

        public string Motivation { get; set; }

        public string CurrentJob { get; set; }

        public string AvailabillityPerDay { get; set; }

        public string TimeContact { get; set; }

        public bool IsJoinToExadel { get; set; }

        public bool IsAgreement { get; set; }
    }
}
