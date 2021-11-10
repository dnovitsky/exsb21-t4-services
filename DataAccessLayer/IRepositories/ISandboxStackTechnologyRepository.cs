using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ISandboxStackTechnologyRepository
    {
        Task<IEnumerable<SandboxStackTechnologyEntityModel>> GetAllAsync();
        Task<IEnumerable<SandboxStackTechnologyEntityModel>> FindByConditionAsync(Expression<Func<SandboxStackTechnologyEntityModel, bool>> expression);
        Task<SandboxStackTechnologyEntityModel> FindByIdAsync(Guid id);
<<<<<<< HEAD
        void CreateAsync(SandboxStackTechnologyEntityModel item);
=======
        Task<SandboxStackTechnologyEntityModel> CreateAsync(SandboxStackTechnologyEntityModel item);
>>>>>>> dev
        void Update(SandboxStackTechnologyEntityModel item);
        void Delete(Guid id);
    }
}
