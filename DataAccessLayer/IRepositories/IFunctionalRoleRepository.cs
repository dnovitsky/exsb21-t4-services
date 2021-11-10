using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IFunctionalRoleRepository
    {
        Task<IEnumerable<FunctionalRoleEntityModel>> GetAllAsync();
        Task<IEnumerable<FunctionalRoleEntityModel>> FindByConditionAsync(Expression<Func<FunctionalRoleEntityModel, bool>> expression);
        Task<FunctionalRoleEntityModel> FindByIdAsync(Guid id);

        Task<FunctionalRoleEntityModel> CreateAsync(FunctionalRoleEntityModel item);

        void Update(FunctionalRoleEntityModel item);
        void Delete(Guid id);
    }
}
