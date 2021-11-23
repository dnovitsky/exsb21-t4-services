using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class CandidateLanguageEntityModel
    {        
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid CandidateId { get; set; }
        public virtual CandidateEntityModel Candidate { get; set; }
        [Required]
        public Guid LanguageId { get; set; }
        public virtual LanguageEntityModel Language { get; set; }
        [Required]
        public Guid LanguageLevelId { get; set; }
        public virtual LanguageLevelEntityModel LanguageLevel { get; set; }

    }
}
