using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DbMigrations.EntityModels.BaseModels;

namespace DbMigrations.EntityModels
{
    public class CalendarEventEntityModel : IdEntityModel
    {
        public Guid InterviewerId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [ForeignKey(nameof(InterviewerId))]
        public virtual UserEntityModel User { get; set; }

        public virtual IList<InterviewEventEntityModel> InterviewEvents { get; set; }
    }
}
