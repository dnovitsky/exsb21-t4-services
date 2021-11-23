using DataAccessLayer.IRepositories;
using DbMigrations.Data;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class LocationRepository : Repository<LocationEntityModel>, ILocationRepository
    {
        public AppDbContext db;
        public LocationRepository(AppDbContext context)
            : base(context)
        {
            db = context;
        }

        public async Task<LocationEntityModel> FindByIdAsync(Guid id)
        {
            return await db.Locations.FindAsync(id);
        }

        public async Task<IEnumerable<LocationEntityModel>> GetAllAsync()
        {
            return await Task.Run(() => db.Locations.AsEnumerable());
        }
        public async Task CreateAsync(LocationEntityModel item)
        {
            await db.Locations.AddAsync(item);
        }

        public void Update(LocationEntityModel item)
        {
            db.Locations.Update(item);
            // db.SaveChanges();
        }
        public void Delete(Guid id)
        {

        }
    }
}
