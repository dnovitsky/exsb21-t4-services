using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Interfaces
{
    public interface ILocationService : IDisposable
    {
        Task<bool> AddLocationAsync(LocationDtoModel languageDto);
        Task<Nullable<Guid>> AddLocationByNameAsync(string locationName);
        Task<IEnumerable<LocationDtoModel>> GetAllLocationsAsync();
        Task<IEnumerable<LocationDtoModel>> FindLocationsAsync(Expression<Func<LocationEntityModel, bool>> expression);
        // Task<IEnumerable<LocationDtoModel>> GetLocationBySandboxIdAsync(Guid id);
        void UpdateLocation(LocationDtoModel languageDto);
        Task<LocationDtoModel> FindLocationByIdAsync(Guid id);
        void DeleteLocation(Guid id);
    }
}
