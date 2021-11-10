using DbMigrations.EntityModels;
using DbMigrations.Data;
using DataAccessLayer.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class AvailabilityTypeRepository : Repository<AvailabilityTypeEntityModel>, IAvailabilityTypeRepository
    {
        public AvailabilityTypeRepository(AppDbContext context)
            : base(context)
        { }
    }
}
