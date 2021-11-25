using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IEventMemberRepository
    {
        Task<IEnumerable<EventMemberEntityModel>> GetAllAsync();
        Task<IEnumerable<EventMemberEntityModel>> FindByConditionAsync(Expression<Func<EventMemberEntityModel, bool>> expression);
        Task<EventMemberEntityModel> FindByIdAsync(Guid id);
        Task<EventMemberEntityModel> CreateAsync(EventMemberEntityModel item);
        void Update(EventMemberEntityModel item);
        void Delete(Guid id);
    }
}
