using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class CandidateProcessDtoModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public List<CandidateDtoModel> Candidates { get; set; }

        public string Status { get; set; }
        public string TestResult { get; set; }
        public DateTime CreateDate { get; set; }

        // FeedbackList
        public List<dynamic> Feedbacks { get; set; } = new ();
    }
}
