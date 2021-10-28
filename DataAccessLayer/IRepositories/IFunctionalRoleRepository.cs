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
        void Create(FunctionalRoleEntityModel item);
        void Update(FunctionalRoleEntityModel item);
        void Delete(int id);
    }
}
