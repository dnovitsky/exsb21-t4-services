using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbMigrations.EntityModels
{
    public class CandidateSandboxEntityModel
    {
        public CandidateSandboxEntityModel()
        {
            CandidateProcesses = new List<CandidateProccesEntityModel>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid SandboxId { get; set; }
        public virtual SandboxEntityModel Sandbox { get; set; }

        [Required]
        public Guid CandidateId { get; set; }
        public virtual CandidateEntityModel Candidate { get; set; }

        public Nullable<Guid> CandidateProjectRoleId { get; set; }
        public virtual CandidateProjectRoleEntityModel CandidateProjectRole { get; set; }

        public Nullable<Guid> TeamId { get; set; }
        public virtual TeamEntityModel Team { get; set; }

        [Required]
        public Guid StackTechnologyId { get; set; }
        public virtual StackTechnologyEntityModel StackTechnology { get; set; }


        public string Motivation { get; set; }

        public string CurrentJob { get; set; }

        public string TimeContact { get; set; }

        public bool IsJoinToExadel { get; set; }

        public Guid SandboxLanguageId { get; set; }

        public bool IsAgreement { get; set; }
        [Required]
        public Guid AvailabilityTypeId { get; set; }
        public virtual AvailabilityTypeEntityModel AvailabilityType { get; set; }

        public virtual IList<CandidateProccesEntityModel> CandidateProcesses { get; set; }
    }
}
