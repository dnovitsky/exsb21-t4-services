using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class CandidateProcessDtoModel
    {
        public Guid Id { get; set; }

        public StatusDtoModel Status { get; set; }
        public string TestResult { get; set; }
        public DateTime CreateDate { get; set; }

        public IEnumerable<FeedbackDtoModel> Feedbacks { get; set; }
        public IEnumerable<CandidateProcessTestTaskDtoModel>? СandidateProccessTestTasks { get; set; }
    }
}
