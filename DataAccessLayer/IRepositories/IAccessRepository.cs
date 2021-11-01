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
        Task<IEnumerable<AccessEntityModel>> GetAllAsync(Func<IQueryable<AccessEntityModel>, IQueryable<AccessEntityModel>> include = null);
        Task<IEnumerable<AccessEntityModel>> FindByConditionAsync(Expression<Func<AccessEntityModel, bool>> expression);
        Task<AccessEntityModel> FindByIdAsync(int id);
        void CreateAsync(AccessEntityModel item);
        void UpdateAsync(AccessEntityModel item);
        void DeleteAsync(int id);
    }
}
