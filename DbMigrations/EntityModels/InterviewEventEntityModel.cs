using System;
using System.ComponentModel.DataAnnotations.Schema;
using DbMigrations.EntityModels.BaseModels;

namespace DbMigrations.EntityModels
{
    public class InterviewEventEntityModel : IdEntityModel
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Guid CalendarEventId { get; set; }

        public Guid CandidateSandboxId { get; set; }

        [ForeignKey(nameof(CalendarEventId))]
        public virtual CalendarEventEntityModel CalendarEvent { get; set; }

        [ForeignKey(nameof(CandidateSandboxId))]
        public virtual CandidateSandboxEntityModel CandidateSandbox { get; set; }
    }
}
