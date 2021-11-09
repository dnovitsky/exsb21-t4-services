using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAvailabilityService
    {
        Task<IEnumerable<AvailabilityDtoModel>> GetAllAvailabilitiesAsync();
    }
}
