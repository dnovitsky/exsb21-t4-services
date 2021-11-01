using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IStatusRepository
    {
        IEnumerable<StatusEntityModel> GetAll();
        IEnumerable<StatusEntityModel> FindByCondition(Expression<Func<StatusEntityModel, bool>> expression);
        void CreateAsync(StatusEntityModel item);
        void UpdateAsync(StatusEntityModel item);
        void DeleteAsync(int id);
    }
}
