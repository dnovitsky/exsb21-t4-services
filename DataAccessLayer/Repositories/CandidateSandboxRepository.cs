using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using DbMigrations.Data;
using DataAccessLayer.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class CandidateSandboxRepository : Repository<CandidateSandboxEntityModel>, ICandidateSandboxRepository
    {
        public CandidateSandboxRepository(AppDbContext context)
            : base(context)
        { }
    }
}
