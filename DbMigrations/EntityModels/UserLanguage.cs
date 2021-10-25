using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DbMigrations.EntityModels
{
    public class UserLanguage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public List<User> Users { get; set; }
        [Required]
        public List<Language> Languages { get; set; }
        [Required]
        public List<LanguageLevel> LanguageLevels { get; set; }
    }
    
}
