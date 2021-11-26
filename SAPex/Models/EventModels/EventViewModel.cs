using System;
using DbMigrations.EntityModels.DataTypes;

namespace SAPex.Models.EventModels
{
    public class EventViewModel : CreateEventViewModel
    {
        public EventType Type { get; set; }

        public Guid Id { get; set; }
    }
}
