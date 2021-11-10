using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAvailabilityTypeService
    {
        Task<IEnumerable<AvailabilityTypeDtoModel>> GetAllAvailabilitiesAsync();

    }
}
