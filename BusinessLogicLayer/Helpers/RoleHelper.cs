using System;
using System.Collections.Generic;
using System.Linq;
using DbMigrations.Data;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Helpers
{
    public class RoleHelper:IApplicationHelper
    {
        private AppDbContext _dbContext;
        public RoleHelper(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        private List<string> roles = new() { "EDU manager", "Mentor", "Interviewer", "Recruiter", "Admin" };
        public void CreateTestData()
        {
            if (!_dbContext.FunctionalRoles.Any())
            {
                roles.ForEach(role =>
                {
                    _dbContext.FunctionalRoles.Add(new FunctionalRoleEntityModel
                    {
                        Name =role,
                    });

                });

            }
            _dbContext.SaveChanges();
        }

        public void ClearTestData()
        {
            foreach (var role in roles)
            {
                var entity = _dbContext.FunctionalRoles.Where(x => x.Name == role).FirstOrDefault();
                if (entity == null) break;
                _dbContext.Remove(entity);
            }
            _dbContext.SaveChanges();
        }
    }
}
