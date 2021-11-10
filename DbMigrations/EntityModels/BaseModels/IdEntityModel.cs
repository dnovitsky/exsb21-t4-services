using System;
using System.ComponentModel.DataAnnotations;

namespace DbMigrations.EntityModels.BaseModels
{
    public class IdEntityModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}
