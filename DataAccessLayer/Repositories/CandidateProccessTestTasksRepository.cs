using DataAccessLayer.IRepositories;
using DbMigrations.Data;
using DbMigrations.EntityModels;

namespace DataAccessLayer.Repositories
{
    public class CandidateProccessTestTasksRepository : Repository<CandidateProccessTestTasksEntityModel>, ICandidateProccessTestTasksRepository
    {
        public CandidateProccessTestTasksRepository(AppDbContext context)
            : base(context)
        { }
    }
}
