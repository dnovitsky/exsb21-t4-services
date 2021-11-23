using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class FeedbackEntityModel
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public virtual UserEntityModel User { get; set; }

        public int? MentoreGrade { get; set; }

        public int? InterviewerGrade { get; set; }

        public int? AdminGrade { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public string UserReview { get; set; }

        [Required]
        public Guid CandidateProccesId { get; set; }
        public virtual CandidateProccesEntityModel CandidateProcces { get; set; }
    }
}
