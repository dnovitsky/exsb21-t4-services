﻿using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    
    public class CandidateProcesEntityModel
    {
        public CandidateProcesEntityModel()
        {
            Feedbacks = new List<FeedbackEntityModel>();
            СandidateProccessTestTasks = new List<CandidateProcessTestTaskEntityModel>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid StatusId { get; set; }
        public virtual StatusEntityModel Status { get; set; }

        [Required]
        public Guid CandidateSandboxId { get; set; }
        public virtual CandidateSandboxEntityModel CandidateSandbox { get; set; }

        public string TestResult { get; set; }
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public virtual IList<FeedbackEntityModel> Feedbacks { get; set; }
        
        public virtual IList<CandidateProcessTestTaskEntityModel> СandidateProccessTestTasks { get; set; }
    }
}