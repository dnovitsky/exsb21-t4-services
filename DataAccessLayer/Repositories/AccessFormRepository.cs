using DataAccessLayer.IRepositories;
using DbMigrations.Data;
using DbMigrations.EntityModels;

namespace DataAccessLayer.Repositories
{
    public class AccessFormRepository : Repository<AccessFormEntityModel>, IAccessFormRepository
    {
        public AccessFormRepository(AppDbContext context)
            : base(context)
        { }
    }
}
