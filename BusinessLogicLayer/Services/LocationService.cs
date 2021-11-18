using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Mapping;
using BusinessLogicLayer.Interfaces;
using System.Linq.Expressions;
using AutoMapper;
using DataAccessLayer.Service;

namespace BusinessLogicLayer.Services
{
    public class LocationService
    {
        protected readonly LocationProfile profile;
        private readonly IUnitOfWork unitOfWork;

        public LocationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            profile = new LocationProfile();
        }
        public async Task<bool> AddLocationAsync(LocationDtoModel languageDto)
        {
            try
            {
                LocationEntityModel languageEM = profile.mapToEM(languageDto);
                await unitOfWork.Locations.CreateAsync(languageEM);
                await unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void DeleteLocation(Guid id)
        {
            unitOfWork.Locations.Delete(id);
        }

        public async Task<LocationDtoModel> FindLocationByIdAsync(Guid id)
        {
            LocationEntityModel languageEM = await unitOfWork.Locations.FindByIdAsync(id);
            LocationDtoModel languageDto = profile.mapToDto(languageEM);
            return languageDto;
        }

        public async Task<IEnumerable<LocationDtoModel>> FindLocationsAsync(Expression<Func<LocationEntityModel, bool>> expression)
        {
            IEnumerable<LocationEntityModel> languagesEM = await unitOfWork.Locations.FindByConditionAsync(expression);
            return profile.mapListToDto(languagesEM);
        }

        public async Task<IEnumerable<LocationDtoModel>> GetAllLocationsAsync()
        {
            IEnumerable<LocationEntityModel> languagesEM = await Task.Run(() => unitOfWork.Locations.GetAllAsync());
            return profile.mapListToDto(languagesEM);
        }

        public void UpdateLocation(LocationDtoModel languageDto)
        {
            LocationEntityModel languageEM = profile.mapToEM(languageDto);
            unitOfWork.Locations.Update(languageEM);
            unitOfWork.SaveAsync();
        }

        public void Dispose()
        {

        }
    }
}
