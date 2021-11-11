using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;

namespace SAPexAuthService.Services
{
    public class UserService
    {
        private IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserEntityModel>> FindAllAsync()
        {
            var users=await _unitOfWork.Users.GetAllAsync();
            return users;
        }

        public async Task<UserEntityModel> FindByEmailAsync(string email)
        {
            var user= await _unitOfWork.Users.FindByConditionAsync(u=>u.Email==email);
            return user.First();
        }

        public async Task<UserEntityModel> FindByEmailAndPasswordAsync(string email, string password)
        {
            var users = await _unitOfWork.Users.FindByConditionAsync(x => x.Email == email && x.Password == password);
            return users.FirstOrDefault();
        }

        public async Task<UserEntityModel> FindByIdAsync(Guid userId)
        {
            var user= await _unitOfWork.Users.FindByIdAsync(userId);
            return user;
        }
    }
}
