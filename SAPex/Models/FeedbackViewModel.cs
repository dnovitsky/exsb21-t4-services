using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAPex.Models
{
    public class FeedbackViewModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid RatingId { get; set; }

        public DateTime CreateDate { get; set; }

        public string UserReview { get; set; }

        public Guid CandidateProccesId { get; set; }
    }
}
