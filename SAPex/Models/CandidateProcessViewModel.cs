using System;
using System.Collections.Generic;

namespace SAPex.Models
{
    public class CandidateProcessViewModel
    {
        public Guid Id { get; set; }

        public StatusViewModel Status { get; set; }

        public string TestResult { get; set; }

        public DateTime CreateDate { get; set; }

        public IEnumerable<FeedbackViewModel> Feedbacks { get; set; }

        public IEnumerable<CandidateProcessTestTasksViewModel>? СandidateProccessTestTasks { get; set; }
    }
}
