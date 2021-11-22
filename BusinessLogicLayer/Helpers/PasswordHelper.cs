using System;
using System.Collections.Generic;
using System.Linq;
using DbMigrations.Data;

namespace BusinessLogicLayer.Helpers
{
    public class PasswordHelper : IApplicationHelper
    {
        private AppDbContext _dbContext;
        public PasswordHelper(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        Dictionary<string, string> dictionary = new Dictionary<string, string>
        {
            { "manager@gmail.com" , "manager123456" },
            { "mentor@gmail.com","mentor123456" },
            { "interviewer@gmail.com","interviewer123456" },
            { "developer.noor.cullen@gmail.com","interviewer123456"},
            { "recruiter@gmail.com","recruiter123456" },
            { "admin@gmail.com","admin123456" },
        };
     
        public void CreateTestData()
        {
            foreach (var dic in dictionary)
            {
                var user = _dbContext.Users.Where(x => x.Email == dic.Key && x.Password == dic.Value).FirstOrDefault();
                if (user != null)
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                    _dbContext.Update(user);
                }
            }
            _dbContext.SaveChanges();
        }

        public void ClearTestData()
        {

            throw new NotImplementedException();
        }
    }
}
