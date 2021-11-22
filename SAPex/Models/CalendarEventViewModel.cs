using System;
using System.Collections.Generic;

namespace SAPex.Models
{
    public class CalendarEventViewModel
    {
        public Guid Id { get; set; }

        public Guid InterviewerId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public IEnumerable<InterviewEventViewModel> InterviewEvents { get; set; }
    }
}
