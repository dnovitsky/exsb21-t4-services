using BusinessLogicLayer.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserSandboxService
    {
        Task<bool> AddUserSandboxAsync(UserSandboxDtoModel userSandboxDto);

        Task<bool> AddUserSandboxListByIdsAsync(Guid sandboxId, IEnumerable<Guid> stackTechnologyIds);

        Task<bool> DeleteUserSandboxListByIdsAsync(Guid sandboxId);
    }
}
