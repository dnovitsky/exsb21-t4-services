using BusinessLogicLayer.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserCandidateSandboxService 
    {
        Task<bool> AddUserCandidateSandboxesAsync(Guid userId, IEnumerable<Guid> candidateSandboxIds);
        Task<bool> AddUserCandidateSandboxAsync(UserCandidateSandboxDtoModel userCandidateSandboxDto);

    }
}
