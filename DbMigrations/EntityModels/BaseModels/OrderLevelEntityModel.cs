using System.ComponentModel.DataAnnotations;

namespace DbMigrations.EntityModels.BaseModels
{
    public class OrderLevelEntityModel : NameEntityModel
    {
        [Required]
        public int OrderLevel { get; set; }
    }
}
