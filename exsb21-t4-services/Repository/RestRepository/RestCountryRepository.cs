using System;
using System.Collections.Generic;
using exsb21_t4_services.Models.RestModels;
using RestSharp;

namespace exsb21_t4_services.Repository.RestRepository
{
    public class RestCountryRepository : IRestRepository
    {
        private readonly RestClient client;
        public RestCountryRepository()
        {
            client = new RestClient("https://countriesnow.space");
        }

        public RestCountryResponse GetCountry() {
            var request = new RestRequest("/api/v0.1/countries", Method.GET);
            return client.Execute<RestCountryResponse>(request).Data; ;
        } 
    }
}
