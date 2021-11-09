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
        Task<IEnumerable<AvailabilityEntityModel>> GetAllAsync();
        Task<IEnumerable<AvailabilityEntityModel>> FindByConditionAsync(Expression<Func<AvailabilityEntityModel, bool>> expression);
        Task<AvailabilityEntityModel> FindByIdAsync(int id);
        void CreateAsync(AvailabilityEntityModel item);
        void Update(AvailabilityEntityModel item);
        void Delete(int id);
    }
}
