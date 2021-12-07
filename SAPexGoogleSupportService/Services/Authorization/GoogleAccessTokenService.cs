using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using SAPexGoogleSupportService.Interfaces;
using SAPexGoogleSupportService.Models;

namespace SAPexGoogleSupportService.Services.Authorization
{
    public class GoogleAccessTokenService : IGoogleAccessTokenService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AuthGoogleService _authGoogleService;

        public GoogleAccessTokenService(IUnitOfWork unitOfWork, AuthGoogleService authGoogleService)
        {
            _unitOfWork = unitOfWork;
            _authGoogleService = authGoogleService;
        }

        public string GetRedirectUrl(string state)
        {
            return _authGoogleService.GetRedirectUrl(state);
        }

        public async Task<GoogleResponse<GoogleAccessTokenEntityModel>> FindByUserIdAsync(Guid userId)
        {
            var token = (await _unitOfWork.GoogleAccessTokens.FindByConditionAsync(x => x.UserId == userId)).FirstOrDefault();
            if (token == null)
            {
                return new GoogleResponse<GoogleAccessTokenEntityModel> { Message = "Token not found", Code = 404 };
            }

            long expires = token.Created_in + (token.Expires_in * 1000);
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            if (expires <= now)
            {
                var updatedToken = await _authGoogleService.UpdateAsync(token);
                token.Created_in = now;
                token.Expires_in = updatedToken.Expires_in;
                token.Access_token = updatedToken.Access_token;
                token.Token_type = updatedToken.Token_type;
                token = await UpdateAsync(token);
            }
            return new GoogleResponse<GoogleAccessTokenEntityModel> { Data = token, Code = 200 };


        }

        public async Task<GoogleResponse<GoogleAccessTokenEntityModel>> CreateAsync(string code, string state)
        {
            var token = await _authGoogleService.GetAsync(code, state);
            if (token == null)
            {
                return new GoogleResponse<GoogleAccessTokenEntityModel>() { Message = "Can not get Google Tokens", Code = 404 };
            }

            var googleUser = await _authGoogleService.GetAsync(token);
            if (googleUser == null)
            {
                return new GoogleResponse<GoogleAccessTokenEntityModel>() { Message = "Can not get Google User Information", Code = 405 };
            }

            var sapexUser = (await _unitOfWork.Users.FindByConditionAsync(x => x.Email == googleUser.email)).FirstOrDefault();
            if (sapexUser == null)
            {
                return new GoogleResponse<GoogleAccessTokenEntityModel>() { Message = "Not Sapex User", Code = 406 };
            }

            var oldToken = (await _unitOfWork.GoogleAccessTokens.FindByConditionAsync(x => x.UserId == sapexUser.Id)).FirstOrDefault();

            if (oldToken == null)
            {
                token.UserId = sapexUser.Id;
                token = await CreateAsync(token);
                return new GoogleResponse<GoogleAccessTokenEntityModel> { Data = token, Code = 200 };
            }


            oldToken.Created_in = token.Created_in;
            oldToken.Expires_in = token.Expires_in;
            oldToken.Access_token = token.Access_token;
            oldToken.Refresh_token = token.Refresh_token;
            oldToken.Token_type = token.Token_type;
            oldToken = await UpdateAsync(oldToken);
            return new GoogleResponse<GoogleAccessTokenEntityModel> { Data = oldToken, Code = 200 };
        }

        public async Task<GoogleAccessTokenEntityModel> FindByIdAsync(Guid id)
        {
            return await _unitOfWork.GoogleAccessTokens.FindByIdAsync(id);
        }

        public async Task<IEnumerable<GoogleAccessTokenEntityModel>> FindAllAsync()
        {
            var tokens = await _unitOfWork.GoogleAccessTokens.GetAllAsync();
            return tokens;
        }

        public async Task<GoogleAccessTokenEntityModel> CreateAsync(GoogleAccessTokenEntityModel item)
        {
            item = await _unitOfWork.GoogleAccessTokens.CreateAsync(item);
            return item;
        }

        public async Task<GoogleAccessTokenEntityModel> UpdateAsync(GoogleAccessTokenEntityModel item)
        {
            _unitOfWork.GoogleAccessTokens.Update(item);
            await _unitOfWork.SaveAsync();
            return item;
        }

        public GoogleAccessTokenEntityModel Delete(Guid id)
        {
            _unitOfWork.GoogleAccessTokens.Delete(id);
            return null;
        }

    }
}
