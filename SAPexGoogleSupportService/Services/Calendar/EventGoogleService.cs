using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using SAPexGoogleSupportService.Interfaces;
using SAPexGoogleSupportService.Models;
using SAPexGoogleSupportService.Models.Authorization;
using SAPexGoogleSupportService.Models.Calendar;

namespace SAPexGoogleSupportService.Services.Calendar
{
    public class EventGoogleService
    {
        private readonly RestClient restClient = new();
        private readonly GoogleSettingsModel _googleSettings;
        private readonly IGoogleAccessTokenService _googleTokenService;

        public EventGoogleService(IGoogleAccessTokenService googleTokenService, IOptions<GoogleSettingsModel> googleSettings)
        {
            _googleSettings = googleSettings.Value;
            _googleTokenService = googleTokenService;
        }

        public async Task<GoogleResponse<List<EventGoogleModel>>> GetAllAsync(Guid ownerId)
        {
            var token = await _googleTokenService.FindByUserIdAsync(ownerId);
            if (token.Code != 200)
            {
                return new GoogleResponse<List<EventGoogleModel>> { Code = 404, Message="Google Token Not Found"};
            }
            RestRequest request = GetRequest(token.Data);
            restClient.BaseUrl = new Uri(_googleSettings.google_calendar_events_uri);
            var response = await restClient.ExecuteGetAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject events = JObject.Parse(response.Content);
                var allEvents = events["items"].ToObject<List<EventGoogleModel>>();
                return new GoogleResponse<List<EventGoogleModel>> { Data = allEvents, Code = 200};
            }
            return null;
        }

        public async Task<GoogleResponse<EventGoogleModel>> DeleteAsync(Guid ownerId, string id)
        {
            var token = await _googleTokenService.FindByUserIdAsync(ownerId);
            if (token.Code != 200)
            {
                return new GoogleResponse<EventGoogleModel> { Code = 404, Message = "Google Token Not Found" };
            }
            RestRequest request = GetRequest(token.Data);
            restClient.BaseUrl = new Uri($"{_googleSettings.google_calendar_events_uri}/{id}");
            var response = await restClient.ExecuteAsync(request, Method.DELETE);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return new GoogleResponse<EventGoogleModel> { Code = 200, Message = "Event removed from google calendar" };
            }
            return new GoogleResponse<EventGoogleModel> { Code = 405, Message = "Event does not removed from google calendar" };
        }

        public async Task<GoogleResponse<EventGoogleModel>> CreateAsync(Guid ownerId, EventGoogleModel item)
        {
            var token = await _googleTokenService.FindByUserIdAsync(ownerId);
            if (token.Code != 200)
            {
                return new GoogleResponse<EventGoogleModel> { Code = 404, Message = "Google Token Not Found" };
            }
            RestRequest request = GetRequest(token.Data);

            item.Start.DateTime = DateTime.Parse(item.Start.DateTime).ToString("yyyy-MM-dd'T'HH:mm:ss");
            item.End.DateTime = DateTime.Parse(item.End.DateTime).ToString("yyyy-MM-dd'T'HH:mm:ss");

            var model = JsonConvert.SerializeObject(item, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            request.AddParameter("application/json", model, ParameterType.RequestBody);

            restClient.BaseUrl = new Uri($"{_googleSettings.google_calendar_events_uri}?sendUpdates=all");
            var response = restClient.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject googleEvent = JObject.Parse(response.Content);
                return new GoogleResponse<EventGoogleModel> { Code = 200, Data = googleEvent.ToObject<EventGoogleModel>() };
            }
            return new GoogleResponse<EventGoogleModel> { Code = 405, Message = "Event does not created from google calendar" };
        }

        /*
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
        */

        public async Task<GoogleResponse<EventGoogleModel>> Update(Guid ownerId, EventGoogleModel item)
        {
            var token = await _googleTokenService.FindByUserIdAsync(ownerId);
            if (token.Code != 200)
            {
                return new GoogleResponse<EventGoogleModel> { Code = 404, Message = "Google Token Not Found" };
            }
            RestRequest request = GetRequest(token.Data);
            item.Start.DateTime = DateTime.Parse(item.Start.DateTime).ToString("yyyy-MM-dd'T'HH:mm:ss.fffK");
            item.End.DateTime = DateTime.Parse(item.End.DateTime).ToString("yyyy-MM-dd'T'HH:mm:ss.fffK");
            var model = JsonConvert.SerializeObject(item, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            request.AddParameter("application/json", model, ParameterType.RequestBody);
            restClient.BaseUrl = new System.Uri($"{_googleSettings.google_calendar_events_uri}/{item.Id}?sendUpdates=all");
            var response = restClient.Patch(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return new GoogleResponse<EventGoogleModel> { Code = 200, Message = "Event updated from google calendar" };

            }
            return new GoogleResponse<EventGoogleModel> { Code = 405, Message = "Event does not updated from google calendar" };

        }



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
