using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbMigrations.EntityModels
{
    public class CandidateEntityModel
    {
        public CandidateEntityModel()
        {
            CandidateLanguages = new List<CandidateLanguageEntityModel>();
            CandidateTechSkills = new List<CandidateTechSkillEntityModel>();
            CandidateSandboxes = new List<CandidateSandboxEntityModel>();
        }

        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Location { get; set; }
        
        [Required]
        public string Skype { get; set; }
        
        [Required]
        public string Phone { get; set; }
        
        [Required]
        public string Education { get; set; }
        
        [Required]
        public string CV { get; set; }

        public virtual IList<CandidateLanguageEntityModel> CandidateLanguages { get; set; }
        
        public virtual IList<CandidateTechSkillEntityModel> CandidateTechSkills { get; set; }
        
        public virtual IList<CandidateSandboxEntityModel> CandidateSandboxes { get; set; }
    }
}
