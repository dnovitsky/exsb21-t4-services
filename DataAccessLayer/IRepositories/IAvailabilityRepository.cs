using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IAvailabilityRepository
    {
        Task<IEnumerable<AvailabilityTypeEntityModel>> GetAllAsync();
        Task<IEnumerable<AvailabilityTypeEntityModel>> FindByConditionAsync(Expression<Func<AvailabilityTypeEntityModel, bool>> expression);
        Task<AvailabilityTypeEntityModel> FindByIdAsync(int id);
        void CreateAsync(AvailabilityTypeEntityModel item);
        void Update(AvailabilityTypeEntityModel item);
        void Delete(int id);
    }
}
