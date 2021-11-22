using System;
using System.Collections.Generic;
using System.Linq;
using DbMigrations.Data;

namespace BusinessLogicLayer.Helpers
{
    public class GoogleAccessTokenHelper:IApplicationHelper
    {
        private AppDbContext _dbContext;
        List<string> users = new()
        {
            "manager@gmail.com" ,
            "mentor@gmail.com",
            "interviewer@gmail.com",
            "developer.noor.cullen@gmail.com",
            "recruiter@gmail.com",
            "admin@gmail.com"
        };
        public GoogleAccessTokenHelper(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void ClearTestData()
        {
           
        }

        public void CreateTestData()
        {
            foreach (var login in users)
            {
                var user = _dbContext.Users.Where(x => x.Email == login).FirstOrDefault();
                if (user == null) break;
                var token = _dbContext.GoogleAccessTokens.Where(x => x.UserId == user.Id).FirstOrDefault();
                if (token == null) break;
                _dbContext.GoogleAccessTokens.Remove(token);

            }
            _dbContext.SaveChanges();
        }
    }
}
