using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using DataAccessLayer.IRepositories;
using DbMigrations.Data;

namespace DataAccessLayer.Repositories
{
    public class CandidateRepository : Repository<CandidateEntityModel>, ICandidateRepository
    {
        public CandidateRepository(AppDbContext context)
            :base(context)
        { }
        public CandidateEntityModel Search(string search)
        {
            throw new NotImplementedException();
        }
    }
}
