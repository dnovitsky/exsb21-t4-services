﻿using System;
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
        public string Surname { get; set; }

        public string Email { get; set; }

        public Nullable<Guid> LocationId { get; set; }
        public virtual LocationEntityModel Location { get; set; }

        [Required]
        public string Skype { get; set; }
        
        [Required]
        public string Phone { get; set; }

        public string ProfessionaCertificates { get; set; }

        public string AdditionalSkills { get; set; }


        public virtual IList<CandidateLanguageEntityModel> CandidateLanguages { get; set; }
        
        public virtual IList<CandidateTechSkillEntityModel> CandidateTechSkills { get; set; }
        
        public virtual IList<CandidateSandboxEntityModel> CandidateSandboxes { get; set; }
    }
}
