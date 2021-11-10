using DbMigrations.EntityModels.BaseModels;
using System.Collections.Generic;

namespace DbMigrations.EntityModels
{
    public class AvailabilityTypeEntityModel : OrderLevelEntityModel
    {
        public AvailabilityTypeEntityModel()
        {
            CandidateSandboxes = new List<CandidateSandboxEntityModel>();
        }

        public IList<CandidateSandboxEntityModel> CandidateSandboxes { get; set; }
    }
}
