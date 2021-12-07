using System;
using System.Collections.Generic;
using System.Linq;
using DbMigrations.Data;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Helpers
{
    public class UserHelper : IApplicationHelper
    {
        private AppDbContext _dbContext;
        public UserHelper(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private List<UserEntityModel> users = new List<UserEntityModel>
        {
            new UserEntityModel
                {
                    Name = "June",
                    Surname = "Cullen",
                    Email = "manager@gmail.com",
                    Password = "manager123456",
                    LocationId = null,
                    Phone = "+998998756090",
                    Skype = "Skype:username"
                },
            new UserEntityModel
                {
                    Name = "Helena",
                    Surname = "Ford",
                    Email = "mentor@gmail.com",
                    Password = "mentor123456",
                    LocationId = null,
                    Phone = "+998998756191",
                    Skype = "Skype:username"
                },
            new UserEntityModel
                {
                    Name = "Bill",
                    Surname = "York",
                    Email = "interviewer.sapex.2021@gmail.com",
                    Password = "interviewer123456",
                    LocationId = null,
                    Phone = "+998998756292",
                    Skype = "Skype:username"
                },
            new UserEntityModel
                {
                    Name = "Nurmukhammad",
                    Surname = "Sunatullaev",
                    Email = "developer.noor.cullen@gmail.com",
                    Password = "recruiter123456",
                    LocationId = null,
                    Phone = "+998998756292",
                    Skype = "Skype:username"
                },
            new UserEntityModel
                {
                    Name = "Matilda",
                    Surname = "Gisburg",
                    Email = "recruiter@gmail.com",
                    Password = "recruiter123456",
                    LocationId = null,
                    Phone = "+998998756393",
                    Skype = "Skype:username"
                },
            new UserEntityModel
                {
                    Name = "Eleon",
                    Surname = "York",
                    Email = "admin@gmail.com",
                    Password = "admin123456",
                    LocationId = null,
                    Phone = "+998998756393",
                    Skype = "Skype:username"
                }
        };
        
        public  void CreateTestData()
        {
            foreach (var user in users)
            {
                var entity = _dbContext.Users.Where(x => x.Email == user.Email).FirstOrDefault();
                if (entity == null) _dbContext.Users.Add(user);
            }
            _dbContext.SaveChanges();
        }

        public  void ClearTestData()
        {
            foreach (var user in users)
            {
                var entity = _dbContext.Users.Where(x => x.Email == user.Email).FirstOrDefault();
                if (entity == null) break;
                _dbContext.Remove(entity);
            }
            _dbContext.SaveChanges();
        }
    }
}
