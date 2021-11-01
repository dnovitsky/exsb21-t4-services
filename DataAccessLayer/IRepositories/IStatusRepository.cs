using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IStatusRepository
    {
        Task<IEnumerable<StatusEntityModel>> GetAllAsync(Func<IQueryable<StatusEntityModel>, IQueryable<StatusEntityModel>> include = null);
        Task<IEnumerable<StatusEntityModel>> FindByConditionAsync(Expression<Func<StatusEntityModel, bool>> expression);
        Task<StatusEntityModel> FindByIdAsync(int id);
        void CreateAsync(StatusEntityModel item);
        void UpdateAsync(StatusEntityModel item);
        void DeleteAsync(int id);
    }
}
