using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ISandboxRepository
    {
        Task<IEnumerable<SandboxEntityModel>> GetAllAsync();
        Task<IEnumerable<SandboxEntityModel>> FindByConditionAsync(Expression<Func<SandboxEntityModel, bool>> expression);
        Task<SandboxEntityModel> FindByIdAsync(Guid id);
<<<<<<< HEAD
        void CreateAsync(SandboxEntityModel item);
=======
        Task<SandboxEntityModel> CreateAsync(SandboxEntityModel item);
>>>>>>> dev
        void Update(SandboxEntityModel item);
        void Delete(Guid id);
    }
}
