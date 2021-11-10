using System.ComponentModel.DataAnnotations;

namespace DbMigrations.EntityModels.BaseModels
{
    public class NameEntityModel : IdEntityModel
    {
        [Required]
        public string Name { get; set; }
    }
}
