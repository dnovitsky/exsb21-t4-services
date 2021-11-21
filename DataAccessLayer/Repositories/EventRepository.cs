using System;
using DataAccessLayer.IRepositories;
using DbMigrations.Data;
using DbMigrations.EntityModels;

namespace DataAccessLayer.Repositories
{
    public class EventRepository : Repository<EventEntityModel>, IEventRepository
    {
        public EventRepository(AppDbContext context)
            : base(context)
        { }
    }
}
