using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class UserCandidateSandboxService : IUserCandidateSandboxService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserCandidateSandboxProfile profile;

        public UserCandidateSandboxService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.profile = new UserCandidateSandboxProfile();

        }

        public async Task<bool> AddUserCandidateSandboxesAsync(Guid userId, IEnumerable<Guid> candidateSandboxIds)
        {
            try
            {
                IList<UserCandidateSandboxDtoModel> userSandboxDtoModels = new List<UserCandidateSandboxDtoModel>();

                foreach (var id in candidateSandboxIds)
                {
                    UserCandidateSandboxDtoModel item = new UserCandidateSandboxDtoModel { UserId = userId, CandidateSandboxId = id };
                    await AddUserCandidateSandboxAsync(item);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> AddUserCandidateSandboxAsync(UserCandidateSandboxDtoModel userCandidateSandboxDto)
        {
            try
            {
                UserCandidateSandboxEntityModel userCandidateSandboxEM = profile.mapToEM(userCandidateSandboxDto);
                await unitOfWork.UserCandidateSandboxes.CreateAsync(userCandidateSandboxEM);
                await unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
