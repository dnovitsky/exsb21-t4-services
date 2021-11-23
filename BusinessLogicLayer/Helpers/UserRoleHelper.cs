﻿using System;
using System.Collections.Generic;
using System.Linq;
using DbMigrations.Data;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Helpers
{
    public class UserRoleHelper : IApplicationHelper
    {
        private AppDbContext _dbContext;
        public UserRoleHelper(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        Dictionary<string, string> dictionary = new Dictionary<string, string>
        {
            { "manager@gmail.com" , "EDU manager" },
            { "mentor@gmail.com","Mentor" },
            { "interviewer@gmail.com","Interviewer" },
            { "developer.noor.cullen@gmail.com","Interviewer"},
            { "recruiter@gmail.com","Recruiter" },
            { "admin@gmail.com","Admin" },
        };
        public void CreateTestData()
        {
                foreach (var dic in dictionary)
                {
                    var user = _dbContext.Users.Where(x => x.Email == dic.Key).SingleOrDefault();
                    var role = _dbContext.FunctionalRoles.Where(x => x.Name == dic.Value).SingleOrDefault();

                    var user_role= _dbContext.UserFunctionalRoles.Where(x => x.UserId == user.Id && x.FunctionalRoleId == role.Id).FirstOrDefault();
                    if(user_role ==null)
                        _dbContext.UserFunctionalRoles.Add(new UserFunctionalRoleEntityModel
                        {
                            FunctionalRoleId = role.Id,
                            UserId = user.Id
                        });
                }
                _dbContext.SaveChanges();
        }

        public void ClearTestData()
        {
        }
    }
}
