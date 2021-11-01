using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IFunctionalRoleRepository
    {
        IEnumerable<FunctionalRoleEntityModel> GetAll();
        IEnumerable<FunctionalRoleEntityModel> FindByCondition(Expression<Func<FunctionalRoleEntityModel, bool>> expression);
        void CreateAsync(FunctionalRoleEntityModel item);
        void UpdateAsync(FunctionalRoleEntityModel item);
        void DeleteAsync(int id);
    }
}
