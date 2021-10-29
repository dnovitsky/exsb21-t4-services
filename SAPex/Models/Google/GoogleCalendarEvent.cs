using System;
using System.Collections.Generic;

namespace SAPex.Models
{
    public class GoogleCalendarEvent
    {
        public GoogleCalendarEvent()
        {
            this.Start = new EventDateTime ()
            {
                TimeZone = "Europe/Istanbul"
            };
            this.End = new EventDateTime()
            {
                TimeZone = "Europe/Istanbul"
            };

        }
        public string Id { get; set; }
        public string Summary{ get; set; }

        public string Description { get; set; }

        public EventDateTime Start { get; set; }

        public EventDateTime End { get; set; }

        public List<Attendees> Attendees { get; set; }
    }
}
public class Attendees {
    public string Email { get; set; }
}

public class EventDateTime
{
    public string DateTime { get; set; }
    public string TimeZone { get; set; }
}
