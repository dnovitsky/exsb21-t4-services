using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface ILocationRepository
    {
        Task<IEnumerable<LocationEntityModel>> GetAllAsync();
        Task<IEnumerable<LocationEntityModel>> FindByConditionAsync(Expression<Func<LocationEntityModel, bool>> expression);
        Task<LocationEntityModel> FindByIdAsync(Guid id);
        Task<LocationEntityModel> CreateAsync(LocationEntityModel item);

        void Update(LocationEntityModel item);
        void Delete(Guid id);
    }
}
