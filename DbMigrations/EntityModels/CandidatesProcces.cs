using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public enum Status {
        Draft, Rejected, Test, NeedVerification, NeedRecruiter, Interview, 
        Approved, Questinable, Sandbox, FinalInterview
    };
    public class CandidatesProcces
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public List<Candidate> CandidateId { get; set; }
        [Required]
        public Status CurrentStatus { get; set; }
        public string TestResult { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public List<Feedback> FeedbackId { get; set; }
    }
}
