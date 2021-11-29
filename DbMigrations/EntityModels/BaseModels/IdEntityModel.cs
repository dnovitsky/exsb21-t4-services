using System;
using System.ComponentModel.DataAnnotations;

namespace DbMigrations.EntityModels.BaseModels
{
    public class IdEntityModel
    {
        public IdEntityModel()
        {
            Id = Guid.NewGuid();
        }

        public IdEntityModel(Guid id)
        {
            Id = id;
        }

        [Key]
        public Guid Id { get; set; }
    }
}
