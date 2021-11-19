using System;
using System.Collections.Generic;
using BusinessLogicLayer.DtoModels.BaseModels;

namespace BusinessLogicLayer.DtoModels
{
    public class CalendarEventDtoModel : ItemDtoModel
    {
        public Guid InterviewerId { get; set; }

        public string Surname { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public IEnumerable<InterviewEventDtoModel> InterviewEvents { get; set; }
    
    }
}
