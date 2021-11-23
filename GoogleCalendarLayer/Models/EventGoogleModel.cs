using System;
using System.Collections.Generic;

namespace GoogleCalendarLayer.Models
{
    public class EventGoogleModel
    {
        public string Id { get; set; }
        public DateTimeGoogleModel Start { get; set; }
        public DateTimeGoogleModel End { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public IList<AttendeeGoogleModel> Attendees { get; set; }
    }
}
