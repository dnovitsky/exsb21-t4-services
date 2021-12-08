using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using RestSharp;
using SAPexSchedulerService.Interfaces.Services;
using SAPexSchedulerService.Models;
using SAPexSchedulerService.Models.Base;

namespace SAPexSchedulerService.Services
{
    public class EmailSendService : IEmailSendService
    {
        public  void  Run()
        {
            RestClient restClient = new();
            restClient.BaseUrl = new Uri($"http://64.227.114.210:9090/api/emails/filter?status={EmailStatusType.ReadyForSend}");
            var responseEmails = restClient.Get(new RestRequest());
            if (responseEmails.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JArray emailsJson = JArray.Parse(responseEmails.Content);
                IEnumerable<EmailModel> emails= emailsJson.ToObject<IEnumerable<EmailModel>>();
                foreach (var email in emails)
                {
                    restClient.BaseUrl = new Uri($"http://64.227.114.210:9090/api/emails/{email.Id}/send");
                    var response = restClient.Put(new RestRequest());
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Console.WriteLine("Sent");
                    }
                }
            }
        }
    }
}
