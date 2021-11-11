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
        public virtual SandboxEntityModel Sandbox { get; set; }

        [Required]
        public Guid CandidateId { get; set; }
        public virtual CandidateEntityModel Candidate { get; set; }

        [Required]
        public Guid CandidateProjectRoleId { get; set; }
        public virtual CandidateProjectRoleEntityModel CandidateProjectRole { get; set; }

        [Required]
        public Guid TeamId { get; set; }
        public virtual TeamEntityModel Team { get; set; }

        [Required]
        public Guid StackTechnologyId { get; set; }
        public virtual StackTechnologyEntityModel StackTechnology { get; set; }

        [Required]
        public Guid CandidateProcessId { get; set; }
        public virtual CandidateProccesEntityModel CandidateProcess { get; set; }

        [Required]
        public Guid AvailabilityTypeId { get; set; }
        public virtual AvailabilityTypeEntityModel AvailabilityType { get; set; }
    }
}
