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
        Task<IEnumerable<AccessFormEntityModel>> GetAllAsync(Func<IQueryable<AccessFormEntityModel>, IQueryable<AccessFormEntityModel>> include = null);
        Task<IEnumerable<AccessFormEntityModel>> FindByConditionAsync(Expression<Func<AccessFormEntityModel, bool>> expression);
        Task<AccessFormEntityModel> FindByIdAsync(int id);
        void CreateAsync(AccessFormEntityModel item);
        void UpdateAsync(AccessFormEntityModel item);
        void DeleteAsync(int id);
    }
}
