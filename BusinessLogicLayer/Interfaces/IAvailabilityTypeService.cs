using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using DataAccessLayer.Service;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAvailabilityTypeService
    {
        Task<IEnumerable<AvailabilityTypeDtoModel>> GetAllAvailabilitiesAsync();

        Task<PagedList<AvailabilityTypeDtoModel>> GetPageListAsync(int pagesize, int pagenumber);

    }
}
