using System;
using SAPex.Models;
using SAPex.Services.Google.BaseServices;

namespace SAPex.Services.Google.IGoogleSevices
{
    public interface IGoogleCalendarEventService : GoogleBaseService<GoogleCalendarEvent, string>
    {
    }
}
