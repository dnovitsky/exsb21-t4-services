using System;
using System.Collections.Generic;
using SAPexSchedulerService.Data.EntityModels;

namespace SAPexSchedulerService.Repositories
{
    public interface ISandboxRepository
    {
        public List<SandboxEntityModel> FindAll();
        public SandboxEntityModel Update(SandboxEntityModel model);
    }
}
