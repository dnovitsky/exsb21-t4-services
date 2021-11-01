using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IAccessRepository
    {
        IEnumerable<AccessEntityModel> GetAll();
        IEnumerable<AccessEntityModel> FindByCondition(Expression<Func<AccessEntityModel, bool>> expression);
        void CreateAsync(AccessEntityModel item);
        void UpdateAsync(AccessEntityModel item);
        void DeleteAsync(int id);
    }
}
