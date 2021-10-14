using System;
using exsb21_t4_services.Models.RestModels;

namespace exsb21_t4_services.Repository.RestRepository
{
    public interface IRestRepository
    {
        RestCountryResponse GetCountry();
    }
}
