using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IAccessFormRepository
    {
        Task<IEnumerable<AccessFormEntityModel>> GetAllAsync();
        Task<IEnumerable<AccessFormEntityModel>> FindByConditionAsync(Expression<Func<AccessFormEntityModel, bool>> expression);
        Task<AccessFormEntityModel> FindByIdAsync(Guid id);
        Task<AccessFormEntityModel> CreateAsync(AccessFormEntityModel item);
        void Update(AccessFormEntityModel item);
        void Delete(Guid id);
    }
}
