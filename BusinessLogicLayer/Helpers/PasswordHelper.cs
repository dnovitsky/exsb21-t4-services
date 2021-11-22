﻿using System;
using System.Collections.Generic;
using System.Linq;
using DbMigrations.Data;

namespace BusinessLogicLayer.Helpers
{
    public class PasswordHelper : IApplicationHelper
    {
        private AppDbContext _dbContext;
        private const string CONST_TITLE = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
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
                var user = _dbContext.Users.Where(x => x.Email == dic.Key).FirstOrDefault();
                if (user != null)
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(CONST_TITLE+dic.Value);
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
