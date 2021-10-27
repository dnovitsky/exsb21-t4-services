using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DbMigrations.EntityModels
{
    public class UserLanguageEntityModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public UserEntityModel User { get; set; }
        [Required]
        public Guid LanguageId { get; set; }
        public LanguageEntityModel Language { get; set; }
        [Required]
        public Guid LanguageLevelId { get; set; }
        public LanguageLevelEntityModel LanguageLevels { get; set; }
    }
    
}
