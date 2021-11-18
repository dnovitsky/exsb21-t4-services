using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ICalendarEventRepository
    {
        Task<IEnumerable<CalendarEventEntityModel>> GetAllAsync();
        Task<IEnumerable<CalendarEventEntityModel>> FindByConditionAsync(Expression<Func<CalendarEventEntityModel, bool>> expression);
        Task<CalendarEventEntityModel> FindByIdAsync(Guid id);
        Task<CalendarEventEntityModel> CreateAsync(CalendarEventEntityModel item);
        void Update(CalendarEventEntityModel item);
        void Delete(Guid id);
    }
}
