using System;
using System.ComponentModel.DataAnnotations.Schema;
using DbMigrations.EntityModels.BaseModels;

namespace DbMigrations.EntityModels
{
    public class EventEntityModel : IdEntityModel
    {
        public Guid InterviewerId { get; set; }

        public Guid? CandidateSandboxId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string GoogleCalendarEventId { get; set; }

        public string TimeZone { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(InterviewerId))]
        public virtual UserEntityModel User { get; set; }

        [ForeignKey(nameof(CandidateSandboxId))]
        public virtual CandidateSandboxEntityModel CandidateSandbox { get; set; }

    }
}
