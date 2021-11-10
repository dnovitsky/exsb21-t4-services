using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IAccessRepository
    {
        Task<IEnumerable<AccessEntityModel>> GetAllAsync();
        Task<IEnumerable<AccessEntityModel>> FindByConditionAsync(Expression<Func<AccessEntityModel, bool>> expression);
        Task<AccessEntityModel> FindByIdAsync(Guid id);
<<<<<<< HEAD
        void CreateAsync(AccessEntityModel item);
=======
        Task<AccessEntityModel> CreateAsync(AccessEntityModel item);
>>>>>>> dev
        void Update(AccessEntityModel item);
        void Delete(Guid id);
    }
}
