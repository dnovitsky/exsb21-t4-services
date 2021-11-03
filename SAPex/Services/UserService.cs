using System;
using System.Collections.Generic;
using System.Linq;
using DbMigrations.EntityModels;

namespace SAPex.Services
{
    public class UserService
    {
        private List<UserEntityModel> _userRepository = new()
        {
            new UserEntityModel
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
                Surname = "User",
                Email = "admin@gmail.com",
                Password = "admin",
                UserRoles = new List<UserRoleEntityModel>()
                                  {
                                      new UserRoleEntityModel
                                      {
                                          Id = Guid.NewGuid(),
                                          FunctionalRole=new FunctionalRoleEntityModel{  Access="MANAGER"}
                                      }
                                  }
            },
            new UserEntityModel
            {
                Id = Guid.NewGuid(),
                Name = "Normal",
                Surname = "User",
                Email = "user@gmail.com",
                Password = "user",
                UserRoles = new List<UserRoleEntityModel>()
                                  {
                                      new UserRoleEntityModel
                                      {
                                          Id = Guid.NewGuid(),
                                          FunctionalRole=new FunctionalRoleEntityModel{  Access="INTERVIEWER"}
                                      }
                                  }
            }
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
