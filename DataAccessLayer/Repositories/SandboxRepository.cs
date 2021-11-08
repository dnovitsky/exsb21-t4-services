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
            SandboxEntityModel requestData = await db.Sandboxes.FindAsync(id);
            return requestData;
        }

        public async Task<IEnumerable<SandboxEntityModel>> GetAllAsync()
        {
            return await Task.Run(() => db.Sandboxes.AsEnumerable());
        }
        public async void CreateAsync(SandboxEntityModel item)
        {
            await db.Sandboxes.AddAsync(item);
            // await db.SaveChangesAsync();
        }
        public void Delete(Guid id)
        {

        }
    }
}
