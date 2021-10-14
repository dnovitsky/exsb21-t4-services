using System;
using System.Collections.Generic;

namespace exsb21_t4_services.Models.RestModels
{
    public class RestCountryResponse
    {

        public bool Error { get; set; }
        public string Msg { get; set; }
        public List<RestCountry> Data { get; set; }
        public RestCountryResponse()
        {
        }
    }
}
