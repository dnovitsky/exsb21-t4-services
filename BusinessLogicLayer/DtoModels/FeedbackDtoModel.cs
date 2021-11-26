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

        public string Author { get; set; }

        public int? Grade { get; set; }

        public DateTime CreateDate { get; set; }

        public string UserReview { get; set; }

        public Guid CandidateProccesId { get; set; }
    }
}
