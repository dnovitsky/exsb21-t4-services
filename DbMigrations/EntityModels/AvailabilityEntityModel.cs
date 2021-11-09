using System;
using System.ComponentModel.DataAnnotations;

namespace DbMigrations.EntityModels
{
    public class AvailabilityEntityModel
    {
        public AvailabilityEntityModel()
        {            
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
