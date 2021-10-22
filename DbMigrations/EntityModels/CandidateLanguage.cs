using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class CandidateLanguage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public List<Candidate> CandidateId { get; set; }
        [Required]
        public List<Language> LanguageId { get; set; }
        [Required]
        public Level LanguageCandidate { get; set; }
    }
}
