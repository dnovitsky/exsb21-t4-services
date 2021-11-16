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

        Task<UserDtoModel> FindInterviewerByIdAsync(Expression<Func<UserFunctionalRoleEntityModel, bool>> expression);

        Task<IEnumerable<UserDtoModel>> FindInterviewersAsync(Expression<Func<UserFunctionalRoleEntityModel, bool>> expression);
    }
}
