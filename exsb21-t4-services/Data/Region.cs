using System;
namespace exsb21_t4_services.Data
{
    public class Region
    {
        public int Id { get; set; }
        public string RegionName { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public Region()
        {
        }
    }
}
