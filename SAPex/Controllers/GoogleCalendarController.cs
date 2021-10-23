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

    [Route("api/google/calendars")]
    [ApiController]
    public class GoogleCalendarController:ControllerBase
    {
        private const string GOOGLE_TOKEN_PATH = @"GoogleFiles/tokens.json";
        private readonly RestClient restClient = new();
        private readonly RestRequest request = new();

        [HttpGet]
        public ActionResult<IEnumerable<GoogleCalendar>> Get()
        {
            var tokens = JObject.Parse(System.IO.File.ReadAllText(GOOGLE_TOKEN_PATH));

            request.AddQueryParameter("key", "AIzaSyAxAw_wO6NwJchMksGz3VK4Z81EMjHT3vE");
            request.AddHeader("Authorization", "Bearer " + tokens["access_token"]);
            request.AddHeader("Accept", "application/json");

            restClient.BaseUrl = new System.Uri("https://www.googleapis.com/calendar/v3/users/me/calendarList");
            var response = restClient.Get(request);

             if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject events = JObject.Parse(response.Content);
                var allEvents = events["items"].ToObject<IEnumerable<GoogleCalendar>>();
                return Ok(allEvents);
            }

            return BadRequest();

        }

        [HttpGet("{id}")]
        public ActionResult<GoogleCalendar> Get(string id)
        {

            var tokens = JObject.Parse(System.IO.File.ReadAllText(GOOGLE_TOKEN_PATH));


            request.AddQueryParameter("key", "AIzaSyAxAw_wO6NwJchMksGz3VK4Z81EMjHT3vE");
            request.AddHeader("Authorization", "Bearer " + tokens["access_token"]);
            request.AddHeader("Accept", "application/json");

            restClient.BaseUrl = new System.Uri("https://www.googleapis.com/calendar/v3/calendars/" + id);
            var response = restClient.Get(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject events = JObject.Parse(response.Content);
                return events.ToObject<GoogleCalendar>();
            }

            return BadRequest();

        }

        [HttpPost]
        public ActionResult Post([FromBody] GoogleCalendar calendarModel)
        {
            var tokens = JObject.Parse(System.IO.File.ReadAllText(GOOGLE_TOKEN_PATH));

            request.AddQueryParameter("key", "AIzaSyAxAw_wO6NwJchMksGz3VK4Z81EMjHT3vE");
            request.AddHeader("Authorization", "Bearer " + tokens["access_token"]);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            var model = JsonConvert.SerializeObject(calendarModel, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            request.AddParameter("application/json", model, ParameterType.RequestBody);

            restClient.BaseUrl = new System.Uri("https://www.googleapis.com/calendar/v3/calendars");
            var response = restClient.Post(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok();
            }
            return BadRequest();

        }

        [HttpDelete("{id}")]
        public ActionResult<GoogleCalendar> Delete(string id)
        {

            var tokens = JObject.Parse(System.IO.File.ReadAllText(GOOGLE_TOKEN_PATH));


            request.AddQueryParameter("key", "AIzaSyAxAw_wO6NwJchMksGz3VK4Z81EMjHT3vE");
            request.AddHeader("Authorization", "Bearer " + tokens["access_token"]);
            request.AddHeader("Accept", "application/json");

            restClient.BaseUrl = new System.Uri("https://www.googleapis.com/calendar/v3/calendars/" + id);
            var response = restClient.Delete(request);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Ok();
            }

            return BadRequest();

        }

        [HttpPatch("{id}")]
        public ActionResult Patch(string id, [FromBody] GoogleCalendar calendarModel)
        {
            var tokens = JObject.Parse(System.IO.File.ReadAllText(GOOGLE_TOKEN_PATH));

            var model = JsonConvert.SerializeObject(calendarModel, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            request.AddQueryParameter("key", "AIzaSyAxAw_wO6NwJchMksGz3VK4Z81EMjHT3vE");
            request.AddHeader("Authorization", "Bearer " + tokens["access_token"]);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("application/json", model, ParameterType.RequestBody);

            restClient.BaseUrl = new System.Uri("https://www.googleapis.com/calendar/v3/calendars/" + id);
            var response = restClient.Patch(request);
            System.IO.File.WriteAllText("response.json", response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok();
            }
            return BadRequest();

        }
    }
}
