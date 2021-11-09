using System;
using System.ComponentModel.DataAnnotations;

namespace DbMigrations.EntityModels
{
    public class AvailabilityTypeEntityModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
