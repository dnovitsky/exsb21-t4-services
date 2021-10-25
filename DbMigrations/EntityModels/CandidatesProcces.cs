using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    
    public class CandidatesProcces
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public List<Candidate> Candidates { get; set; }
        public Status Status { get; set; }
        public string TestResult { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public List<Feedback> Feedbacks { get; set; }
    }
}
