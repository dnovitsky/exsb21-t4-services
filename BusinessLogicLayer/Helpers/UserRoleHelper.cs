using System;
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
        public void CreateTestData()
        {
            if (!_dbContext.UserFunctionalRoles.Any())
            {
                var manager = _dbContext.Users.Where(x => x.Email == "manager@gmail.com").SingleOrDefault();
                var managerRole = _dbContext.FunctionalRoles.Where(x => x.Name == "manager").SingleOrDefault();

                _dbContext.UserFunctionalRoles.Add(new UserFunctionalRoleEntityModel
                {
                    FunctionalRoleId = managerRole.Id,
                    UserId=manager.Id
                });

                var mentor = _dbContext.Users.Where(x => x.Email == "mentor@gmail.com").SingleOrDefault();
                var mentorRole = _dbContext.FunctionalRoles.Where(x => x.Name == "mentor").SingleOrDefault();

                _dbContext.UserFunctionalRoles.Add(new UserFunctionalRoleEntityModel
                {
                    FunctionalRoleId = mentorRole.Id,
                    UserId = mentor.Id
                });

                var interviewer = _dbContext.Users.Where(x => x.Email == "interviewer@gmail.com").SingleOrDefault();
                var interviewerRole = _dbContext.FunctionalRoles.Where(x => x.Name == "interviewer").SingleOrDefault();

                _dbContext.UserFunctionalRoles.Add(new UserFunctionalRoleEntityModel
                {
                    FunctionalRoleId = interviewerRole.Id,
                    UserId = interviewer.Id
                });

                var recruiter = _dbContext.Users.Where(x => x.Email == "recruiter@gmail.com").SingleOrDefault();
                var recruiterRole = _dbContext.FunctionalRoles.Where(x => x.Name == "recruiter").SingleOrDefault();

                _dbContext.UserFunctionalRoles.Add(new UserFunctionalRoleEntityModel
                {
                    FunctionalRoleId = recruiterRole.Id,
                    UserId = recruiter.Id
                });
            }

            _dbContext.SaveChanges();
        }

        public void ClearTestData()
        {
            throw new NotImplementedException();
        }
    }
}
