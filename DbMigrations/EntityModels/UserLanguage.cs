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
        public User UserId { get; set; }
        [Required]
        public Language LanguageId { get; set; }
        [Required]
        public Level CurrentLevel { get; set; }
    }
    public enum Level
    {
        A1,
        A2,
        B1,
        B2,
        C1,
        C2
    }
}
