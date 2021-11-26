using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DbMigrations.EntityModels.BaseModels;
using DbMigrations.EntityModels.DataTypes;

namespace DbMigrations.EntityModels
{
    public class EventEntityModel : IdEntityModel
    {
        public string Summary { get; set; }

        public string Description { get ; set;}

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public EventType Type { get; set; }

        public string GoogleCalendarEventId { get; set; }

        public string TimeZone { get; set; }

        public Guid OwnerId { get; set; }

        public Guid? CandidateSandboxId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public virtual UserEntityModel User { get; set; }

        [ForeignKey(nameof(CandidateSandboxId))]
        public virtual CandidateSandboxEntityModel CandidateSandbox { get; set; }

        public virtual IList<EventMemberEntityModel> EventMembers { get; set; }

    }
}
