using System;
using SAPex.Repositories.Google.BaseRepositories;

namespace SAPex.Repositories.Google.IGoogleRepositories
{
    public interface IGoogleCalendarRepository : GoogleBaseRepository<IGoogleCalendarEventRepository,string>
    {
    }
}
