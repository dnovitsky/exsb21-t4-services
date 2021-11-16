using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserProfile profile = new UserProfile();

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserDtoModel>> FindUsersAsync(Expression<Func<UserEntityModel, bool>> expression)
        {
            IEnumerable<UserEntityModel> userEM = await unitOfWork.Users.FindByConditionAsync(expression);
            return profile.mapListToDto(userEM);
        }

       
    }
}
