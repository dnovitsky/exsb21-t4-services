using DataAccessLayer.IRepositories;
using DbMigrations.Data;
using DbMigrations.EntityModels;


namespace DataAccessLayer.Repositories
{
    class SandboxLanguageRepository : Repository<SandboxLanguageEntityModel>, ISandboxLanguageRepository
    {
        public SandboxLanguageRepository(AppDbContext context)
            : base(context)
        { }
    }
}
