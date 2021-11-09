using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AvailabilityProfile profile = new AvailabilityProfile();
        public AvailabilityService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<AvailabilityDtoModel>> GetAllAvailabilitiesAsync()
        {
            IEnumerable<AvailabilityEntityModel> availabilitiesEM = await Task.Run(() => unitOfWork.Availabilities.GetAllAsync());
            return profile.mapListToDto(availabilitiesEM);
        }
    }
}
