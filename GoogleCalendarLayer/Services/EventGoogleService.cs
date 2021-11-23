using System;
using System.Collections.Generic;
using DbMigrations.EntityModels;
using GoogleCalendarLayer.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using SAPexAuthService.Models.Google;

namespace GoogleCalendarLayer.Services
{
    public class EventGoogleService 
    {
  
        private readonly RestClient restClient = new();
        private readonly GoogleSettingsModel _googleSettings;

        public EventGoogleService(IOptions<GoogleSettingsModel> googleSettings)
        {
            _googleSettings= googleSettings.Value;
        }


        public EventGoogleModel Add(GoogleAccessTokenEntityModel tokens, EventGoogleModel item)
        {
            RestRequest request = GetRequest(tokens);

            item.Start.DateTime = DateTime.Parse(item.Start.DateTime).ToString("yyyy-MM-dd'T'HH:mm:ss");
            item.End.DateTime = DateTime.Parse(item.End.DateTime).ToString("yyyy-MM-dd'T'HH:mm:ss");

            var model = JsonConvert.SerializeObject(item, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            request.AddParameter("application/json", model, ParameterType.RequestBody);

            restClient.BaseUrl = new Uri($"{_googleSettings.google_calendar_events_uri}?sendUpdates=all");
            var response = restClient.Post(request);
            System.IO.File.WriteAllText("response.json", response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject googleEvent = JObject.Parse(response.Content);
                return googleEvent.ToObject<EventGoogleModel>();
            }
            return null;
        }
        /*
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
        */
        private RestRequest GetRequest(GoogleAccessTokenEntityModel tokens)
        {
            RestRequest request = new();
            request.AddQueryParameter("key", _googleSettings.key);
            request.AddHeader("Authorization", $"{tokens.Token_type} {tokens.Access_token}");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            return request;
        }
    }
}

