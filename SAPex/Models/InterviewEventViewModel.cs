using System;

namespace SAPex.Models
{
    public class InterviewEventViewModel
    {
        public Guid Id { get; set; }

        public Guid CandidateSandboxId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
