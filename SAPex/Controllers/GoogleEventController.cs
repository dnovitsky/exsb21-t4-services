using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using SAPex.Models;

namespace SAPex.Controllers
{
    [Route("api/google/events")]
    [ApiController]
    public class GoogleEventController: ControllerBase
    {

        private const string GOOGLE_CLIENT_SECRET_PATH = @"GoogleFiles/client_secret.json";
        private const string GOOGLE_TOKEN_PATH = @"GoogleFiles/tokens.json";
        private readonly RestClient restClient = new();
        private readonly RestRequest request = new();
        
        [HttpGet]
        public IEnumerable<EventModel> GetEvents()
        {

            var tokens = JObject.Parse(System.IO.File.ReadAllText(GOOGLE_TOKEN_PATH));

          
            request.AddQueryParameter("key", "AIzaSyDLw8Ppi4WPpjbqh3e7P0i6eWehV5YT8iY");
            request.AddHeader("Authorization", "Bearer " + tokens["access_token"]);
            request.AddHeader("Accept", "application/json");

            restClient.BaseUrl = new System.Uri("https://www.googleapis.com/calendar/v3/calendars/primary/events");
            var response = restClient.Get(request);
           if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject events = JObject.Parse(response.Content);
                var allEvents = events["items"].ToObject<IEnumerable<EventModel>>();
                return allEvents;
            }

            return null;

        }

        [HttpPost("create")]
        public ActionResult CreateEvent([FromBody] EventModel eventModel)
        {
            var tokens = JObject.Parse(System.IO.File.ReadAllText(GOOGLE_TOKEN_PATH));
            /*
           eventModel.Summary = "Summary Something";
           eventModel.Description = "Description Something";
           eventModel.Start.DateTime = "11-11-2021 6:00PM";
           eventModel.End.DateTime = "11-11-2021 7:00PM";
          */

            eventModel.Start.DateTime = DateTime.Parse(eventModel.Start.DateTime).ToString("yyyy-MM-dd'T'HH:mm:ss.fffK");
            eventModel.End.DateTime = DateTime.Parse(eventModel.End.DateTime).ToString("yyyy-MM-dd'T'HH:mm:ss.fffK");

            var model = JsonConvert.SerializeObject(eventModel, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            request.AddQueryParameter("key", "AIzaSyDLw8Ppi4WPpjbqh3e7P0i6eWehV5YT8iY");
            request.AddHeader("Authorization", "Bearer " + tokens["access_token"]);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", model, ParameterType.RequestBody);

            restClient.BaseUrl = new System.Uri("https://www.googleapis.com/calendar/v3/calendars/primary/events");
            var response = restClient.Post(request);
            System.IO.File.WriteAllText("response.json", response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                
                return Ok();
            }
            return BadRequest();

        }

        
    }
}
