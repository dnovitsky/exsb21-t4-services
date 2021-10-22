using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    [Table("Samples")]
    public class Sample
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        //[Unique]
        [Required]
        public string Name { get; set; }
        public int? Age { get; set; }
        public override string ToString()
        {
            return $"{Id}-{Name}";
        }
    }
}
