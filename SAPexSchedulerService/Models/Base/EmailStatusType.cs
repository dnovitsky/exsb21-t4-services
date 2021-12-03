using System;
namespace SAPexSchedulerService.Models.Base
{
    public enum EmailStatusType
    {
        None = 0,
        ReadyForSend = 1,
        InProcess = 2,
        Sent = 3,
        Fail = 4
    }
}
