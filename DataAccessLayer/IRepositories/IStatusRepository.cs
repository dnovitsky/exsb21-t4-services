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
        Task<IEnumerable<StatusEntityModel>> GetAllAsync();
        Task<IEnumerable<StatusEntityModel>> FindByConditionAsync(Expression<Func<StatusEntityModel, bool>> expression);
        Task<StatusEntityModel> FindByIdAsync(Guid id);
        void CreateAsync(StatusEntityModel item);
        void Update(StatusEntityModel item);
        void Delete(Guid id);
    }
}
