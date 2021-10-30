using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class LanguageLevelEntityModel
    {
        public LanguageLevelEntityModel()
        {
            CandidateLanguages = new List<CandidateLanguageEntityModel>();
            UserLanguages = new List<UserLanguageEntityModel>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public IList<CandidateLanguageEntityModel> CandidateLanguages { get; set; }
        public IList<UserLanguageEntityModel> UserLanguages { get; set; }
    }
}
