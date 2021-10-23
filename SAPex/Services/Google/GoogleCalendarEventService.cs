using System;
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
    public class GoogleCalendarEventService : IGoogleCalendarEventService
    {
        private readonly string GOOGLE_API_KEY;
        private readonly string GOOGLE_CALENDAR_EVENT_URL;
        private readonly RestClient restClient = new();

        private readonly IGoogleOAuthService oAuthService;

        public GoogleCalendarEventService(IConfiguration configuration, IGoogleOAuthService oAuthService)
        {
            this.oAuthService = oAuthService;
            GOOGLE_API_KEY = configuration.GetSection("GoogleStrings").GetSection("key").Value;
            GOOGLE_CALENDAR_EVENT_URL = configuration.GetSection("GoogleStrings").GetSection("google_calendar_events_uri").Value;
        }


        public bool Add(string email, GoogleCalendarEvent item)
        {
            RestRequest request = GetRequest(email);

            item.Start.DateTime = DateTime.Parse(item.Start.DateTime).ToString("yyyy-MM-dd'T'HH:mm:ss.fffK");
            item.End.DateTime = DateTime.Parse(item.End.DateTime).ToString("yyyy-MM-dd'T'HH:mm:ss.fffK");

            var model = JsonConvert.SerializeObject(item, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            request.AddParameter("application/json", model, ParameterType.RequestBody);

            restClient.BaseUrl = new System.Uri($"{GOOGLE_CALENDAR_EVENT_URL}?sendUpdates=all");
            var response = restClient.Post(request);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
        public bool Delete(string email, string id)
        {
            RestRequest request = GetRequest(email);
            restClient.BaseUrl = new System.Uri($"{GOOGLE_CALENDAR_EVENT_URL}/{id}");
            var response = restClient.Delete(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        public List<GoogleCalendarEvent> Get(string email)
        {
            RestRequest request = GetRequest(email);

            restClient.BaseUrl = new System.Uri(GOOGLE_CALENDAR_EVENT_URL);
            var response = restClient.Get(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject events = JObject.Parse(response.Content);
                var allEvents = events["items"].ToObject<List<GoogleCalendarEvent>>();
                return allEvents;
            }

            return null;
        }
        public GoogleCalendarEvent Get(string email, string id)
        {
            RestRequest request = GetRequest(email);
            restClient.BaseUrl = new System.Uri($"{GOOGLE_CALENDAR_EVENT_URL}/{id}");
            var response = restClient.Get(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject events = JObject.Parse(response.Content);
                return events.ToObject<GoogleCalendarEvent>();
            }

            return null;
        }
        public bool Update(string email, GoogleCalendarEvent item)
        {
            RestRequest request = GetRequest(email);

            item.Start.DateTime = DateTime.Parse(item.Start.DateTime).ToString("yyyy-MM-dd'T'HH:mm:ss.fffK");
            item.End.DateTime = DateTime.Parse(item.End.DateTime).ToString("yyyy-MM-dd'T'HH:mm:ss.fffK");

            var model = JsonConvert.SerializeObject(item, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            request.AddParameter("application/json", model, ParameterType.RequestBody);
            restClient.BaseUrl = new System.Uri($"{GOOGLE_CALENDAR_EVENT_URL}/{item.Id}?sendUpdates=all");
            var response = restClient.Patch(request);
            System.IO.File.WriteAllText("response.json", response.Content);
            return response.StatusCode == System.Net.HttpStatusCode.OK;

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
