using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDtoModel>> FindUsersAsync(Expression<Func<UserEntityModel, bool>> expression);

        Task<UserDtoModel> FindByIdAsync(Guid id);

        Task<UserDtoModel> FindByIdConditionAsync(Expression<Func<UserFunctionalRoleEntityModel, bool>> expression);

        Task<IEnumerable<UserDtoModel>> FindAllByConditionAsync(Expression<Func<UserFunctionalRoleEntityModel, bool>> expression);

        Task<IEnumerable<UserDtoModel>> GetUsersBySandboxIdConditionFuncRole(Expression<Func<UserFunctionalRoleEntityModel, bool>> expression, Guid sandboxId);

        Task<IEnumerable<UserDtoModel>> FindByUserCandidateSandboxConditionAsync(
            Expression<Func<UserCandidateSandboxEntityModel, bool>> expression,
            string userFunctionalRoleName);
    }
}
