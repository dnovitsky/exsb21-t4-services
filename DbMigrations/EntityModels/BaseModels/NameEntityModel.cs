using System;
using System.ComponentModel.DataAnnotations;

namespace DbMigrations.EntityModels.BaseModels
{
    public class NameEntityModel : IdEntityModel
    {
        public NameEntityModel(): base()
        {
            Name = "";
        }

        public NameEntityModel(string name) : base()
        {
            Name = name;
        }

        public NameEntityModel(Guid id, string name) : base(id)
        {
            Name = name;
        }

        [Required]
        public string Name { get; set; }
    }
}
