using System;
using System.Collections.Generic;

namespace SAPex.Models.EventModels
{
    public class CreateInterviewEventViewModel : CreateEventViewModel
    {
        public Guid CandidateSandboxId { get; set; }

        public IEnumerable<Guid> Members { get; set; }
    }
}
