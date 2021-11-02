using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using DbMigrations.Data;
using DataAccessLayer.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class CandidateProccesRepository : Repository<CandidateProccesEntityModel>, ICandidateProccesRepository
    {
        public CandidateProccesRepository(AppDbContext context)
            : base(context) 
        { }
    }
}
