using System;
using System.Collections.Generic;

namespace exsb21_t4_services.Data
{
    public class Country
    {
        public int Id{ get; set;}
        public string CountryName { get; set; }

        List<Region> Regions { get; set; }

        public Country()
        {
        }
    }
}
