using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using DataAccessLayer.Service;

namespace DataAccessLayer.IRepositories
{
    public interface IAvailabilityTypeRepository
    {
        Task<IEnumerable<AvailabilityTypeEntityModel>> GetAllAsync();
        Task<PagedList<AvailabilityTypeEntityModel>> GetPageAsync(int pagesize, int pagenumber);
        Task<IEnumerable<AvailabilityTypeEntityModel>> FindByConditionAsync(Expression<Func<AvailabilityTypeEntityModel, bool>> expression);
        Task<AvailabilityTypeEntityModel> FindByIdAsync(Guid id);
<<<<<<< HEAD
        void CreateAsync(AvailabilityTypeEntityModel item);
=======
        Task<AvailabilityTypeEntityModel> CreateAsync(AvailabilityTypeEntityModel item);
>>>>>>> dev
        void Update(AvailabilityTypeEntityModel item);
        void Delete(Guid id);
    }
}
