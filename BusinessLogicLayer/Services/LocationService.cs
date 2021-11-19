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
    public class LocationService: ILocationService
    {
        protected readonly LocationProfile profile;
        private readonly IUnitOfWork unitOfWork;

        public LocationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            profile = new LocationProfile();
        }

        public async Task<Nullable<Guid>> AddLocationByNameAsync(string locationName)
        {
            try
            {
                LocationEntityModel locationEM = profile.mapToEM(new LocationDtoModel(locationName));
                var location = await unitOfWork.Locations.CreateAsync(locationEM);
                await unitOfWork.SaveAsync();
                return location.Id;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> AddLocationAsync(LocationDtoModel locationDto)
        {
            try
            {
                LocationEntityModel locationEM = profile.mapToEM(locationDto);
                await unitOfWork.Locations.CreateAsync(locationEM);
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
            LocationEntityModel locationEM = await unitOfWork.Locations.FindByIdAsync(id);
            LocationDtoModel locationDto = profile.mapToDto(locationEM);
            return locationDto;
        }

        public async Task<IEnumerable<LocationDtoModel>> FindLocationsAsync(Expression<Func<LocationEntityModel, bool>> expression)
        {
            IEnumerable<LocationEntityModel> locationEM = await unitOfWork.Locations.FindByConditionAsync(expression);
            return profile.mapListToDto(locationEM);
        }

        public async Task<IEnumerable<LocationDtoModel>> GetAllLocationsAsync()
        {
            IEnumerable<LocationEntityModel> locations = await unitOfWork.Locations.GetAllAsync();
            return profile.mapListToDto(locations);
        }

        public void UpdateLocation(LocationDtoModel locationDto)
        {
            LocationEntityModel locationEM = profile.mapToEM(locationDto);
            unitOfWork.Locations.Update(locationEM);
            unitOfWork.SaveAsync();
        }

        public void Dispose()
        {

        }
    }
}
