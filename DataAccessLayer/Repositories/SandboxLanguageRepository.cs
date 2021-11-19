using DataAccessLayer.IRepositories;
using DbMigrations.Data;
using DbMigrations.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    class SandboxLanguageRepository : Repository<SandboxLanguageEntityModel>, ISandboxLanguageRepository
    {
        private AppDbContext db;
        public SandboxLanguageRepository(AppDbContext context)
            : base(context)
        {
            db = context;
        }

        public async Task UpdateBySandboxId(IEnumerable<SandboxLanguageEntityModel> sandboxLanguages)
        {
            db.SandboxLanguages.UpdateRange(sandboxLanguages);
        }
    }
}
