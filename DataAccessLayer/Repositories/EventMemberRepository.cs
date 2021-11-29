using System;
using DataAccessLayer.IRepositories;
using DbMigrations.Data;
using DbMigrations.EntityModels;

namespace DataAccessLayer.Repositories
{
    public class EventMemberRepository : Repository<EventMemberEntityModel>, IEventMemberRepository
    {
        public EventMemberRepository(AppDbContext context)
            : base(context)
        { }
    }
}
