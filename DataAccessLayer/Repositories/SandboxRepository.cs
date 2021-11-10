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
    public class SandboxRepository : Repository<SandboxEntityModel>, ISandboxRepository
    {
        public AppDbContext db;
        public SandboxRepository(AppDbContext context)
            : base(context)
        {
            db = context;
        }

        public async Task<SandboxEntityModel> FindByIdAsync(Guid id)
        {
            return await db.Sandboxes.FindAsync(id);
        }

        public async Task<IEnumerable<SandboxEntityModel>> GetAllAsync()
        {
            return await Task.Run(() => db.Sandboxes.AsEnumerable());
        }
        public async Task CreateAsync(SandboxEntityModel item)
        {
            await db.Sandboxes.AddAsync(item);
        }

        public void Update(SandboxEntityModel item)
        {
            db.Sandboxes.Update(item);
            // db.SaveChanges();
        }
        public void Delete(Guid id)
        {

        }
    }
}
