using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class FeedbackDtoModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public int? MentoreGrade { get; set; }

        public int? InterviewerGrade { get; set; }

        public int? AdminGrade { get; set; }

        public DateTime CreateDate { get; set; }

        public string UserReview { get; set; }

        public Guid CandidateProccesId { get; set; }
    }
}
