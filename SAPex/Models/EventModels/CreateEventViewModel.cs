using System;

namespace SAPex.Models.EventModels
{
    public class CreateEventViewModel
    {
        public Guid OwnerId { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
