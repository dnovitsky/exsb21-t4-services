using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;

namespace SAPexAuthService.Services
{
    public class UserRefreshTokenService
    {
        private IUnitOfWork _unitOfWork;
        public UserRefreshTokenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(UserRefreshTokenEntityModel model)
        {
            await _unitOfWork.UserRefreshTokens.CreateAsync(model);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public bool Update(UserRefreshTokenEntityModel model)
        {
            _unitOfWork.UserRefreshTokens.Update(model);
            return true;
        }

        public async Task<UserRefreshTokenEntityModel> FindByRefreshTokenAsync(string refreshToken)
        {
            var result =await _unitOfWork.UserRefreshTokens.FindByConditionAsync(res => res.Token==refreshToken);
            return result.First();
        }
    }
}
