using System;
using System.Collections.Generic;
using System.Linq;
using DbMigrations.EntityModels;

namespace SAPex.Services
{
    public class UserRefreshTokenService
    {
        private List<UserRefreshTokenEntityModel> _userRefreshTokenRepository = new();

        public UserRefreshTokenEntityModel Add(UserRefreshTokenEntityModel userRefreshTokenEntityModel)
        {
            userRefreshTokenEntityModel.Id = Guid.NewGuid();
            _userRefreshTokenRepository.Add(userRefreshTokenEntityModel);
            return userRefreshTokenEntityModel;

        }

        public UserRefreshTokenEntityModel FindByRefreshToken(string refreshToken)
        {
            
            return _userRefreshTokenRepository.SingleOrDefault(x => x.Token == refreshToken);
        }

        public bool Update(UserRefreshTokenEntityModel userRefreshTokenEntityModel)
        {
            _userRefreshTokenRepository.Where(x => x.Id == userRefreshTokenEntityModel.Id).ToList().ForEach(
                x =>
                {
                    x.Id = userRefreshTokenEntityModel.Id;
                    x.Token = userRefreshTokenEntityModel.Token;
                    x.UserId = userRefreshTokenEntityModel.UserId;
                    x.IsRevoked = userRefreshTokenEntityModel.IsRevoked;
                    x.IsUsed = userRefreshTokenEntityModel.IsUsed;
                    x.JwtId = userRefreshTokenEntityModel.JwtId;
                    x.ExpiryDate = userRefreshTokenEntityModel.ExpiryDate;
                    x.AddedDate = userRefreshTokenEntityModel.AddedDate;
                });
            return true;
        }

    }
}
