using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;

namespace BusinessLogicLayer.Interfaces
{
    public interface ISandboxStackTechnologyService
    {
        Task<bool> AddSandboxStackTechnologyAsync(SandboxStackTechnologyDtoModel sandboxStackTechnologyDto);
        Task<bool> AddSandboxStackTechnologyListByIdsAsync(Guid sandboxId, IEnumerable<Guid> stackTechnologyIds);
        Task<bool> UpdateSandboxStackTechnologiesListByIdsAsync(Guid sandboxId, IEnumerable<Guid> stackTechnologyIds);
    }
}
