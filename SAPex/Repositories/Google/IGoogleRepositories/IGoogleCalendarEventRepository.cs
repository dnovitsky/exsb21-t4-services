using System;
using SAPex.Models;
using SAPex.Repositories.Google.BaseRepositories;

namespace SAPex.Repositories.Google.IGoogleRepositories
{
    public interface IGoogleCalendarEventRepository : GoogleBaseRepository<GoogleCalendarEvent,string>
    {
    }
}
