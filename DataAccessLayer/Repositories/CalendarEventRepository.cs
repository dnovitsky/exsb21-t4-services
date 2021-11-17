using System;
using DataAccessLayer.IRepositories;
using DbMigrations.Data;
using DbMigrations.EntityModels;

namespace DataAccessLayer.Repositories
{
    public class CalendarEventRepository : Repository<CalendarEventEntityModel>, ICalendarEventRepository
    {
        public CalendarEventRepository(AppDbContext context)
            : base(context)
        { }
    }
}
