using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventEntityModel>> GetAllAsync();
        Task<IEnumerable<EventEntityModel>> FindByConditionAsync(Expression<Func<EventEntityModel, bool>> expression);
        Task<EventEntityModel> FindByIdAsync(Guid id);
        Task<EventEntityModel> CreateAsync(EventEntityModel item);
        void Update(EventEntityModel item);
        void Delete(Guid id);
    }
}
