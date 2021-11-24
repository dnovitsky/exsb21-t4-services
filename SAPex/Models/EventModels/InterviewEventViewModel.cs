using System;
using DbMigrations.EntityModels.DataTypes;

namespace SAPex.Models.EventModels
{
    public class InterviewEventViewModel : CreateInterviewEventViewModel
    {
        public Guid Id { get; set; }

        public EventType Type { get; set; }
    }
}
