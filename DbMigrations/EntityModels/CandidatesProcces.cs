using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.Models
{
    public enum Status {
        Draft, Rejected, Test, NeedVerification, NeedRecruiter, Interview, 
        Approved, Questinable, Sandbox, FinalInterview
    };
    public class CandidatesProcces
    {
        public int Id { get; set; }
        public Status CurrentStatus { get; set; }
        public string TestResult { get; set; }
        public DateTime CreateDate { get; set; }
        public Feedback FeedbackId { get; set; }
    }
}
