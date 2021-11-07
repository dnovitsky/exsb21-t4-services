using System;
using System.Collections.Generic;
using System.Linq;
using DbMigrations.EntityModels;

namespace DataAccessLayer.Services._Temp
{
    public class UserService
    {
        private List<UserEntityModel> _userRepository = new ()
        {
            new UserEntityModel
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
                Surname = "User",
                Email = "admin@gmail.com",
                Password = "admin",
                UserRoles = new List<UserFunctionalRoleEntityModel>()
                                  {
                                      new UserFunctionalRoleEntityModel
                                      {
                                          Id = Guid.NewGuid(),
                                          FunctionalRole = new FunctionalRoleEntityModel { Name = "MANAGER" },
                                      },
                                  },
            },
            new UserEntityModel
            {
                Id = Guid.NewGuid(),
                Name = "Normal",
                Surname = "User",
                Email = "user@gmail.com",
                Password = "user",
                UserRoles = new List<UserFunctionalRoleEntityModel>()
                                  {
                                      new UserFunctionalRoleEntityModel
                                      {
                                          Id = Guid.NewGuid(),
                                          FunctionalRole = new FunctionalRoleEntityModel { Name = "INTERVIEWER" },
                                      },
                                  },
            },
        };

        public List<UserEntityModel> FindAll()
        {
            return _userRepository;
        }

        public UserEntityModel FindByEmail(string email)
        {
            return _userRepository.SingleOrDefault(x => x.Email == email);
        }

        public UserEntityModel FindByEmailAndPassword(string email, string password)
        {
            return _userRepository.SingleOrDefault(x => x.Email == email && x.Password == password);
        }

        public UserEntityModel FindById(Guid userId)
        {
            return _userRepository.SingleOrDefault(x => x.Id == userId);
        }
    }
}
