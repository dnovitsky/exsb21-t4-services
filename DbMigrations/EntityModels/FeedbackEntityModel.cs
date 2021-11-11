﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class FeedbackEntityModel
    {
        public FeedbackEntityModel()
        {
            CandidateProcceses = new List<CandidateProccesEntityModel>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public virtual UserEntityModel User { get; set; }

        [Required]
        public Guid RatingId { get; set; }
        public virtual RatingEntityModel Rating { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public string UserReview { get; set; }

        public virtual IList<CandidateProccesEntityModel> CandidateProcceses { get; set; }
    }
}
