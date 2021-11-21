using System;

namespace SAPex.Models.EventModels
{
    public class CreateInterviewEventViewModel : CreateEventViewModel
    {
        public Guid CandidateSandboxId { get; set; }
    }
}
