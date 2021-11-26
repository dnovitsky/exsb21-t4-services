using System;
using System.Collections.Generic;

namespace SAPex.Models.EventModels
{
    public class CreateInterviewEventViewModel : CreateEventViewModel
    {
        public Guid CandidateSandboxId { get; set; }

        public IEnumerable<InterviewMemberViewModel> Members { get; set; }
    }
}
