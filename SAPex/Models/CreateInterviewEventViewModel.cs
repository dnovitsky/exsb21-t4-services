using System;

namespace SAPex.Models
{
    public class CreateInterviewEventViewModel
    {
        public Guid CalendarEventId { get; set; }

        public Guid CandidateSandboxId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
