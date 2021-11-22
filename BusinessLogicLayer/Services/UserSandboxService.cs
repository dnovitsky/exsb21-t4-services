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
    public class UserSandboxService : IUserSandboxService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserSandboxProfile profile = new();

        public UserSandboxService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> AddUserSandboxAsync(UserSandboxDtoModel userSandboxDto)
        {
            try
            {
                UserSandBoxEntityModel userSandboxEM = profile.mapToEM(userSandboxDto);
                await unitOfWork.UserSandBoxes.CreateAsync(userSandboxEM);
                await unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddUserSandboxListByIdsAsync(Guid sandboxId, IEnumerable<Guid> userSandboxIds)
        {
            try
            {
                IList<UserSandboxDtoModel> userSandboxDtoModels = new List<UserSandboxDtoModel>();

                foreach (var id in userSandboxIds)
                {
                    UserSandboxDtoModel item = new UserSandboxDtoModel { SandboxId = sandboxId, UserId = id };
                    await AddUserSandboxAsync(item);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUserSandboxListByIdsAsync(Guid sandboxId)
        {
            try
            {
                IEnumerable<UserSandBoxEntityModel> listToDelete = await unitOfWork.UserSandBoxes.FindByConditionAsync(x => x.SandBoxId == sandboxId);
                unitOfWork.UserSandBoxes.DeleteRange(listToDelete);
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
