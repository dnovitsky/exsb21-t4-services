using System;
namespace SAPexAuthService.Models.Google
{
    public class GoogleScope
    {
        public static readonly string CALENDAR = "https://www.googleapis.com/auth/calendar";
        public static readonly string CALENDAR_READ_ONLY="https://www.googleapis.com/auth/calendar.readonly";
        public static readonly string EVENTS = "https://www.googleapis.com/auth/calendar.events";
        public static readonly string EVENTS_READ_ONLY="https://www.googleapis.com/auth/calendar.events.readonly";
        public static readonly string EMAIL = "https://www.googleapis.com/auth/userinfo.email";
        public static readonly string USER_INFO = "https://www.googleapis.com/auth/userinfo.profile";
    }


}