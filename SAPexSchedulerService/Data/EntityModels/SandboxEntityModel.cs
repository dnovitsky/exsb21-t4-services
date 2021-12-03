using System;
using SAPexSchedulerService.Data.Base;

namespace SAPexSchedulerService.Data.EntityModels
{
    public class SandboxEntityModel
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }
        
        public DateTime StartDate { get; set; }
    
        public DateTime EndDate { get; set; }
       
        public DateTime StartRegistration { get; set; }
       
        public DateTime EndRegistration { get; set; }

        public StatusName Status;
    }
}
