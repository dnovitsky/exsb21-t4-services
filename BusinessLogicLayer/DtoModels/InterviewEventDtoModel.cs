using System;
namespace BusinessLogicLayer.DtoModels
{
    public class InterviewEventDtoModel
    {
        public Guid Id { get; set; }

        public Guid CalendarEventId { get; set; }

        public Guid CandidateSandboxId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
