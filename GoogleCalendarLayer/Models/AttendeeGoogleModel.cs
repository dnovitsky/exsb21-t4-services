using System;
namespace GoogleCalendarLayer.Models
{
    public class AttendeeGoogleModel
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        //public string ResponseStatus { get; set; }
        public bool Organizer { get; set; }
        public bool Self { get; set; }
    }
}
