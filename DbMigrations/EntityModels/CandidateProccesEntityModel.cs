using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    
    public class CandidateProccesEntityModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid StatusId { get; set; }
        public virtual StatusEntityModel Status { get; set; }

        public string TestResult { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public Guid FeedbackId { get; set; }
        public virtual FeedbackEntityModel Feedback { get; set; }

      

    }
}
