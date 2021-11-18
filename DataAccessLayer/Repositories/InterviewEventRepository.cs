using DataAccessLayer.IRepositories;
using DbMigrations.Data;
using DbMigrations.EntityModels;

namespace DataAccessLayer.Repositories
{
    public class InterviewEventRepository : Repository<InterviewEventEntityModel>, IInterviewEventRepository
    {
        public InterviewEventRepository(AppDbContext context)
            : base(context)
        { }
    }
}
