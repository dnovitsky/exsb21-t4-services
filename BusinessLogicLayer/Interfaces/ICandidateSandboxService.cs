using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICandidateSandboxService
    {
        Task<CandidateSandboxEntityModel> GetByIdAsync(Guid id);
        Task<CandidateSandboxEntityModel> GetByProccessIdAsync(Guid processId);
    }
}
