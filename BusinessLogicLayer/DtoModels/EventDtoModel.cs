using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.DtoModels
{
    public class EventDtoModel
    {
        public Guid Id { get; set; }

        public Guid OwnerId { get; set; }

        public Guid CandidateSandboxId { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public IEnumerable<Guid> Members{ get; set;}
    }

    
}
