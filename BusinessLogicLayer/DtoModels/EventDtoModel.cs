using System;
namespace BusinessLogicLayer.DtoModels
{
    public class EventDtoModel
    {
        public Guid Id { get; set; }

        public Guid InterviewerId { get; set; }

        public Guid CandidateSandboxId { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }

    public enum EventType
    {
        FREE = 0,
        INTERVIEW = 1,
        ALL = 2,
    }
}
