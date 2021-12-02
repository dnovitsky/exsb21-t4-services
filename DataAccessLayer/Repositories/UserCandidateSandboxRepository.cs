using DataAccessLayer.IRepositories;
using DbMigrations.Data;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserCandidateSandboxRepository : Repository<UserCandidateSandboxEntityModel>, IUserCandidateSandboxRepository
    {
        public UserCandidateSandboxRepository(AppDbContext context)
           : base(context)
        { }
    }
}
