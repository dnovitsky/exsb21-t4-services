using DataAccessLayer.IRepositories;
using DbMigrations.Data;
using DbMigrations.EntityModels;

namespace DataAccessLayer.Repositories
{
    public class CandidateProccessTestTaskRepository : Repository<CandidateProccessTestTaskEntityModel>, ICandidateProccessTestTaskRepository
    {
        public CandidateProccessTestTaskRepository(AppDbContext context)
            : base(context)
        { }
    }
}
