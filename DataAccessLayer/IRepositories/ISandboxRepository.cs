using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ISandboxRepository
    {
        Task<IEnumerable<SandboxEntityModel>> GetAllAsync();
        Task<IEnumerable<SandboxEntityModel>> FindByConditionAsync(Expression<Func<SandboxEntityModel, bool>> expression);
        Task<SandboxEntityModel> FindByIdAsync(Guid id);
        Task<PagedList<SandboxEntityModel>> GetPagedAsync(InputParametrsEntityModel parametrs);
        Task<SandboxEntityModel> CreateAsync(SandboxEntityModel item);

        void Update(SandboxEntityModel item);
        void Delete(Guid id);
    }
}
