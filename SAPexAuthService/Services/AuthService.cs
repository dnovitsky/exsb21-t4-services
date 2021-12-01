using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using Microsoft.Extensions.Options;
using SAPexAuthService.Models;
using SAPexAuthService.Services.Utils;
using SAPexGoogleSupportService.Interfaces;

namespace SAPexAuthService.Services
{
    public class AuthService
    {
        private readonly TokenUtil _tokenUtil;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGoogleAccessTokenService _googleService;
        private const string CONST_TITLE = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        public AuthService(IUnitOfWork unitOfWork, IGoogleAccessTokenService googleService, IOptions<AppSettingsModel> appSettings)
        {
            _unitOfWork = unitOfWork;
            _googleService = googleService;
            _tokenUtil = new(appSettings.Value);
        }

        public string GetGoogleUrl(string state)
        {
            return _googleService.GetRedirectUrl(state);
        }

        public async Task<TokenCredentialsModel> GoogleAuthenticateAsync(string code, string state)
        {
            var response = await _googleService.CreateAsync(code, state);
            if (response.Code != 200)
            {
                return null;
            }
            var user = await _unitOfWork.Users.FindByIdAsync(response.Data.UserId);
            return await GetTokenCredentialsModelAsync(user);
        }

        public async Task<TokenCredentialsModel> AuthenticateAsync(UserCredentialsModel credentials)
        {
            var user = (await _unitOfWork.Users.FindByConditionAsync(x => x.Email == credentials.Email)).FirstOrDefault();
            if (user == null || !BCrypt.Net.BCrypt.Verify(CONST_TITLE + credentials.Password, user.Password))
            {
                return null;
            }
            return await GetTokenCredentialsModelAsync(user);
        }

        public async Task<TokenCredentialsModel> VerifyAndRefreshTokenAsync(TokenCredentialsModel tokenRequest)
        {
            var validToken = await ValidateTokenAsync(tokenRequest);
            if (validToken != null)
            {
                var user = validToken.User;
                _unitOfWork.UserRefreshTokens.Delete(validToken.Id);
                return await GetTokenCredentialsModelAsync(user);
            }
            return null;
        }

        public async Task<bool> RevokeTokenAsync(string email)
        {
            var user = (await _unitOfWork.Users.FindByConditionAsync(x => x.Email == email)).FirstOrDefault();
            var tokens = await _unitOfWork.UserRefreshTokens.FindByConditionAsync(x => x.UserId == user.Id);
            if (tokens.Any())
            {
                foreach (var token in tokens)
                {
                    _unitOfWork.UserRefreshTokens.Delete(token.Id);
                }
                await _unitOfWork.SaveAsync();
                return true;
            }
            return false;
        }

        private async Task<TokenCredentialsModel> GetTokenCredentialsModelAsync(UserEntityModel user)
        {

            var jti = Guid.NewGuid();
            List<string> roles = (from role in user.UserRoles select role.FunctionalRole.Name).ToList();
            var accessToken = _tokenUtil.GetJwtToken(user.Email, roles, jti);
            var refreshToken = _tokenUtil.GetRefreshToken(out int expMonths);
            await RevokeTokenAsync(user.Email);
            await _unitOfWork.UserRefreshTokens.CreateAsync(
                new UserRefreshTokenEntityModel
                {
                    JwtId = jti.ToString(),
                    IsUsed = false,
                    IsRevoked = false,
                    UserId = user.Id,
                    AddedDate = DateTime.UtcNow,
                    ExpiryDate = DateTime.UtcNow.AddMonths(expMonths),
                    Token = refreshToken,
                });
            await _unitOfWork.SaveAsync();
            return new TokenCredentialsModel { AccessToken = accessToken, RefreshToken = refreshToken };
        }

        private async Task<UserRefreshTokenEntityModel> ValidateTokenAsync(TokenCredentialsModel tokens)
        {
            string jti;
            if (_tokenUtil.IsValidToken(tokens.AccessToken, out jti))
            {
                var refreshToken = await _unitOfWork.UserRefreshTokens.FindByConditionAsync(x =>
                x.IsRevoked == false &&
                x.IsUsed == false &&
                x.JwtId == jti &&
                x.Token == tokens.RefreshToken &&
                x.ExpiryDate > DateTime.UtcNow);
                return refreshToken.FirstOrDefault();
            }
            return null;
        }
    }
}
