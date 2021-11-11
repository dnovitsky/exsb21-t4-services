using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Services
{
    public class AvailabilityTypeService : IAvailabilityTypeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AvailabilityProfile profile = new();

        public AvailabilityTypeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AvailabilityTypeDtoModel>> GetAllAvailabilitiesAsync()
        {
            IEnumerable<AvailabilityTypeEntityModel> availabilitiesEM = await Task.Run(() => unitOfWork.AvailabilityTypes.GetAllAsync());
            return profile.mapListToDto(availabilitiesEM);
        }

        public async Task<PagedList<AvailabilityTypeDtoModel>> GetPageListAsync(int pagesize, int pagenumber)
        {
            PagedList<AvailabilityTypeEntityModel> pagedListEM = await unitOfWork.AvailabilityTypes.GetPageAsync(pagesize, pagenumber);
            PagedList<AvailabilityTypeDtoModel> pagedListDto = new PagedList<AvailabilityTypeDtoModel>
            {
                PageList = profile.mapListToDto(pagedListEM.PageList),
                CurrentPage = pagedListEM.CurrentPage,
                TotalPages = pagedListEM.TotalPages
            };
            return pagedListDto;
        }
    }
}
