using System;
using System.ComponentModel.DataAnnotations;

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
        public StackTechnologyEntityModel StackTechnology { get; set; }

        [Required]
        public Guid CandidateProccesId { get; set; }
        public CandidateProccesEntityModel CandidateProcess { get; set; }

        [Required]
        public Guid AvailabilityTypeId { get; set; }
        public AvailabilityTypeEntityModel AvailabilityType { get; set; }
    }
}
