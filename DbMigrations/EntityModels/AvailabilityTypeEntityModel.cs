using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbMigrations.EntityModels
{
    public class AvailabilityTypeEntityModel
    {
        public AvailabilityTypeEntityModel()
        {
            CandidateSandboxes = new List<CandidateSandboxEntityModel>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IList<CandidateSandboxEntityModel> CandidateSandboxes { get; set; }
    }
}
