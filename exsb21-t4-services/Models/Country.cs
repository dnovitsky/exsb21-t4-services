using System;
using System.Collections.Generic;

namespace exsb21_t4_services.Models
{
    public class Country
    {

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public List<Country> cities { get; set; }
        public Country()
        {
        }
    }
}
