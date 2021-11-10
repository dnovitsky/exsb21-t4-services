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
                    Location = "Minsk",
                    Phone = "+998998756090",
                    Skype = "Skype:username"
                },
            new UserEntityModel
                {
                    Name = "Helena",
                    Surname = "Ford",
                    Email = "mentor@gmail.com",
                    Password = "mentor123456",
                    Location = "Minsk",
                    Phone = "+998998756191",
                    Skype = "Skype:username"
                },
            new UserEntityModel
                {
                    Name = "Bill",
                    Surname = "York",
                    Email = "interviewer@gmail.com",
                    Password = "interviewer123456",
                    Location = "Minsk",
                    Phone = "+998998756292",
                    Skype = "Skype:username"
                },
            new UserEntityModel
                {
                    Name = "Matilda",
                    Surname = "Gisburg",
                    Email = "recruiter@gmail.com",
                    Password = "recruiter123456",
                    Location = "Minsk",
                    Phone = "+998998756393",
                    Skype = "Skype:username"
                }
        };
        public  void CreateTestData()
        {
            if (!_dbContext.Users.Any())
            {
                users.ForEach(user =>  _dbContext.Users.Add(user) );
            }
            _dbContext.SaveChanges();
        }

        public  void ClearTestData()
        {
            throw new NotImplementedException();
        }
    }
}
