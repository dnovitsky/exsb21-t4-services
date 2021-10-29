using System;
namespace SAPex.Models
{
    public class GoogleCalendar
    {
        public string Id { get;set; }
        public string Summary { get;set; }
        public string Description { get;set; }
        public string Location { get; set; }
        public string TimeZone { get; set; }
        public string SummaryOverride { get; set; }
        public string AccessRole { get; set; }
        public bool Hidden { get; set; }
        public bool Selected { get; set; }
        public bool Primary { get; set; }
        public bool Deleted { get; set; }
    }
}
