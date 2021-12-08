using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using RestSharp;
using SAPexSchedulerService.Interfaces.Services;
using SAPexSchedulerService.Models;
using SAPexSchedulerService.Models.Base;

namespace SAPexSchedulerService.Services
{
    public class EmailSendService : IEmailSendService
    {
        const string apiHost = "http://64.227.114.210:9090/api/emails/";

        public void Run()
        {
            RestClient restClient = new();
            restClient.BaseUrl = new Uri($"{apiHost}filter?status={EmailStatusType.ReadyForSend}");
            var responseEmails = restClient.Get(new RestRequest());
            if (responseEmails.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JArray emailsJson = JArray.Parse(responseEmails.Content);
                IEnumerable<EmailModel> emails= emailsJson.ToObject<IEnumerable<EmailModel>>();

                if (!emails.Any())
                {
                    return;
                }

                var email = emails.FirstOrDefault();
                restClient.BaseUrl = new Uri($"{apiHost}{email.Id}/send");
                var response = restClient.Put(new RestRequest());

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine("Sent");
                }

                //foreach (var email in emails)
                //{
                //    restClient.BaseUrl = new Uri($"{apiHost}{email.Id}/send");
                //    var response = restClient.Put(new RestRequest());
                //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                //    {
                //        Console.WriteLine("Sent");
                //    }
                //}
            }
        }
    }
}
