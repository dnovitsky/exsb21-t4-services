using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using RestSharp;
using SAPexGoogleSupportService.Models.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SAPexGoogleSupportService.Services.Authorization
{
    public class GoogleOAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RestClient restClient = new();
        private readonly GoogleSettingsModel _googleSettings;

        public GoogleOAuthService(IUnitOfWork unitOfWork, IOptions<GoogleSettingsModel> googleSettings)
        {
            _unitOfWork = unitOfWork;
            _googleSettings = googleSettings.Value;
        }

        public string GetRedirectUrl(string state)
        {
            return $"{_googleSettings.auth_uri}?scope={GoogleScope.ALL}&access_type=offline&include_granted_scopes=true&response_type=code&state={state}&redirect_uri={_googleSettings.redirect_uris}&client_id={_googleSettings.client_id}";
        }

        public async Task<UserEntityModel> AddAsync(string code, string state)
        {
            RestRequest request = GetRequest();
            request.AddQueryParameter("code", code);
            request.AddQueryParameter("grant_type", "authorization_code");
            request.AddQueryParameter("redirect_uri", _googleSettings.redirect_uris);
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            restClient.BaseUrl = new Uri(_googleSettings.token_uri);
            var response = restClient.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject events = JObject.Parse(response.Content);
                GoogleAccessTokenEntityModel userAccess = events.ToObject<GoogleAccessTokenEntityModel>();
                userAccess.Created_in = now;
                restClient.BaseUrl = new Uri($"https://www.googleapis.com/oauth2/v1/userinfo?access_token={userAccess.Access_token}");
                var userInfo = restClient.Get(new RestRequest());

                if (userInfo.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    JObject userInfos = JObject.Parse(userInfo.Content);
                    GoogleUserInfoModel googleUser = userInfos.ToObject<GoogleUserInfoModel>();
                    var user = (await _unitOfWork.Users.FindByConditionAsync(x => x.Email == googleUser.email)).FirstOrDefault();

                    if (user == null)
                    {
                        return null;
                    }

                    var storedToken = (await _unitOfWork.GoogleAccessTokens.FindByConditionAsync(x => x.UserId == user.Id)).FirstOrDefault();
                    if (storedToken == null)
                    {
                        userAccess.UserId = user.Id;
                        userAccess = await _unitOfWork.GoogleAccessTokens.CreateAsync(userAccess);
                    }
                    else
                    {
                        storedToken.Access_token = userAccess.Access_token;
                        storedToken.Refresh_token = userAccess.Refresh_token;
                        storedToken.Created_in = userAccess.Created_in;
                        storedToken.Expires_in = userAccess.Expires_in;
                        _unitOfWork.GoogleAccessTokens.Update(storedToken);
                    }

                    await _unitOfWork.SaveAsync();
                    return user;
                }
            }
            return null;
        }

        public async Task<GoogleAccessTokenEntityModel> UpdateAsync(Guid userId)
        {
            var tokens = await _unitOfWork.GoogleAccessTokens.FindByConditionAsync(x => x.UserId == userId);
            var currentUserAccess = tokens.FirstOrDefault();
            RestRequest request = GetRequest();
            request.AddQueryParameter("grant_type", "refresh_token");
            request.AddQueryParameter("refresh_token", currentUserAccess.Refresh_token);
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            restClient.BaseUrl = new Uri(_googleSettings.token_uri);
            var response = restClient.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject jsonRefresh = JObject.Parse(response.Content);
                GoogleAccessTokenEntityModel refreshUserAccess = jsonRefresh.ToObject<GoogleAccessTokenEntityModel>();
                refreshUserAccess.Id = currentUserAccess.Id;
                refreshUserAccess.UserId = userId;
                refreshUserAccess.Refresh_token = currentUserAccess.Refresh_token;
                refreshUserAccess.Created_in = now;
                _unitOfWork.GoogleAccessTokens.Update(refreshUserAccess);
                return refreshUserAccess;
            }
            return null;
        }

        public async Task<bool> DeleteAsync(Guid userId)
        {
            var tokens = await _unitOfWork.GoogleAccessTokens.FindByConditionAsync(x => x.UserId == userId);
            var userAccess = tokens.FirstOrDefault();
            RestRequest request = GetRequest();
            request.AddQueryParameter("token", userAccess.Access_token);
            restClient.BaseUrl = new Uri(_googleSettings.token_revoke_uri);
            var response = restClient.Post(request);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<GoogleAccessTokenEntityModel> GetGoogleUserAccessTokenAsync(Guid userId)
        {
            var tokens = await _unitOfWork.GoogleAccessTokens.FindByConditionAsync(x => x.UserId == userId);
            var userAccess = tokens.FirstOrDefault();
            long expires = userAccess.Created_in + (userAccess.Expires_in * 1000);
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            if (expires >= now)
            {
                userAccess = await UpdateAsync(userId);
            }
            return userAccess;
        }

        private RestRequest GetRequest()
        {
            RestRequest request = new();
            request.AddQueryParameter("client_id", _googleSettings.client_id);
            request.AddQueryParameter("client_secret", _googleSettings.client_secret);
            return request;
        }
    }
}
