using DataAccessLayer.IRepositories;
using DbMigrations.Data;
using DbMigrations.EntityModels;

namespace DataAccessLayer.Repositories
{
    public class CandidateProcessTestTaskRepository : Repository<CandidateProcessTestTaskEntityModel>, ICandidateProcessTestTaskRepository
    {
        public CandidateProcessTestTaskRepository(AppDbContext context)
            : base(context)
        { }
    }
}
