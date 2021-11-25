using System;

namespace SAPexGoogleSupportService.Models.Authorization
{
    public class GoogleSettingsModel
    {
        public string key { get; set;}
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string project_id { get; set; }
        public string auth_uri { get; set; }
        public string token_uri { get; set; }
        public string token_revoke_uri { get; set; }
        public string auth_provider_x509_cert_url { get; set; }
        public string redirect_uris { get; set; }
        public string google_calendar_events_uri { get; set; }
        public string google_calendar_uri { get; set; }
        public string google_calendar_list_uri { get; set; }
    }
}
