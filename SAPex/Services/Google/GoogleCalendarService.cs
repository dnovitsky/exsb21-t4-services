using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using SAPex.Models;
using SAPex.Services.Google.IGoogleSevices;

namespace SAPex.Services.Google
{
    public class GoogleCalendarService: IGoogleCalendarService
    {
        private readonly string GOOGLE_API_KEY;
        private readonly string GOOGLE_CALENDAR_URL;
        private readonly string GOOGLE_CALENDAR_LIST_URL;
        private readonly RestClient restClient = new();

        private readonly IGoogleOAuthService oAuthService;

        public GoogleCalendarService(IConfiguration configuration, IGoogleOAuthService oAuthService)
        {
            this.oAuthService = oAuthService;
            GOOGLE_API_KEY = configuration.GetSection("GoogleStrings").GetSection("key").Value;
            GOOGLE_CALENDAR_URL = configuration.GetSection("GoogleStrings").GetSection("google_calendar_uri").Value;
            GOOGLE_CALENDAR_LIST_URL = configuration.GetSection("GoogleStrings").GetSection("google_calendar_list_uri").Value;

        }

        public List<GoogleCalendar> Get(string email)
        {
            RestRequest request = GetRequest(email);

            restClient.BaseUrl = new System.Uri(GOOGLE_CALENDAR_LIST_URL);
            var response = restClient.Get(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject events = JObject.Parse(response.Content);
                var calendars = events["items"].ToObject<List<GoogleCalendar>>();
                return calendars;
            }
            return null;
        }
        public GoogleCalendar Get(string email,string calendarId)
        {
            RestRequest request = GetRequest(email);

            restClient.BaseUrl = new System.Uri(GOOGLE_CALENDAR_URL + calendarId);
            var response = restClient.Get(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject calendar = JObject.Parse(response.Content);
                return calendar.ToObject<GoogleCalendar>();
            }

            return null;

        }
        public bool Add(string email, GoogleCalendar calendar)
        {
            RestRequest request = GetRequest(email);
            var model = JsonConvert.SerializeObject(calendar, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            request.AddParameter("application/json", model, ParameterType.RequestBody);

            restClient.BaseUrl = new System.Uri(GOOGLE_CALENDAR_URL);
            var response = restClient.Post(request);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
        public bool Update(string email, GoogleCalendar calendar)
        {
            RestRequest request = GetRequest(email);
            var model = JsonConvert.SerializeObject(calendar, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            request.AddParameter("application/json", model, ParameterType.RequestBody);
            restClient.BaseUrl = new System.Uri(GOOGLE_CALENDAR_URL + calendar.Id);
            var response = restClient.Patch(request);

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
        public bool Delete(string email, string calendarId)
        {
            RestRequest request = GetRequest(email);
            restClient.BaseUrl = new System.Uri(GOOGLE_CALENDAR_URL + calendarId);
            var response = restClient.Delete(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        private RestRequest GetRequest(string email)
        {
            RestRequest request = new();
            var userToken = oAuthService.GetGoogleUserAccessToken(email);
            request.AddQueryParameter("key", GOOGLE_API_KEY);
            request.AddHeader("Authorization", $"{userToken.Token_type} {userToken.Access_token}");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            return request;
        } 
    }
}
