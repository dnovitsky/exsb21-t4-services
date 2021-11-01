using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IAccessFormRepository
    {
        IEnumerable<AccessFormEntityModel> GetAll();
        IEnumerable<AccessFormEntityModel> FindByCondition(Expression<Func<AccessFormEntityModel, bool>> expression);
        void CreateAsync(AccessFormEntityModel item);
        void UpdateAsync(AccessFormEntityModel item);
        void DeleteAsync(int id);
    }
}
