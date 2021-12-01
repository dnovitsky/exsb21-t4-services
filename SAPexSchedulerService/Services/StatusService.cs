using System;
using SAPexSchedulerService.Data.Base;
using SAPexSchedulerService.Repositories;

namespace SAPexSchedulerService.Services
{
    public class StatusService : IStatusService
    {
        private readonly ISandboxRepository _repository;
        public StatusService(ISandboxRepository repository)
        {
            _repository = repository;
        }

        public void StatusJob()
        {
            var now = DateTime.Now;
            var sandboxes = _repository.FindAll();
            foreach (var sandbox in sandboxes)
            {
                if (sandbox.StartRegistration <= now && now < sandbox.EndRegistration)
                {
                    sandbox.Status = StatusName.Registration;
                }
                else if (sandbox.EndRegistration <= now && now < sandbox.StartDate)
                {
                    sandbox.Status = StatusName.Application;
                }
                else if (sandbox.StartDate <= now && now < sandbox.EndDate)
                {
                    sandbox.Status = StatusName.Inprogress;
                }
                else if(sandbox.EndDate < now)
                {
                    sandbox.Status = StatusName.Archive;
                }

                _repository.Update(sandbox);
            }
        }
    }
}
