using System;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using RestSharp;
using SAPexGoogleSupportService.Models.Authorization;

namespace SAPexGoogleSupportService.Services.Authorization
{
    public class AuthGoogleService
    {
        private readonly RestClient restClient = new();
        private readonly GoogleSettingsModel _googleSettings;

        public AuthGoogleService(IOptions<GoogleSettingsModel> googleSettings)
        {
            _googleSettings = googleSettings.Value;
        }

        public string GetRedirectUrl(string state)
        {
            return $"{_googleSettings.auth_uri}?scope={GoogleScope.ALL}&access_type=offline&include_granted_scopes=true&response_type=code&state={state}&redirect_uri={_googleSettings.redirect_uris}&client_id={_googleSettings.client_id}";
        }

        public async Task<GoogleUserInfoModel> GetAsync(GoogleAccessTokenEntityModel token)
        {
            restClient.BaseUrl = new Uri($"https://www.googleapis.com/oauth2/v1/userinfo?access_token={token.Access_token}");
            var userInfo = await restClient.ExecuteGetAsync(new RestRequest());
            if (userInfo.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JObject.Parse(userInfo.Content).ToObject<GoogleUserInfoModel>();
            }

            return null;
        }

        public async Task<GoogleAccessTokenEntityModel> GetAsync(string code, string state)
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
                var token = JObject.Parse(response.Content).ToObject<GoogleAccessTokenEntityModel>();
                token.Created_in = now;
                return token;
            }
            return null;
        }

        public async Task<GoogleAccessTokenEntityModel> UpdateAsync(GoogleAccessTokenEntityModel token)
        {
            RestRequest request = GetRequest();
            request.AddQueryParameter("grant_type", "refresh_token");
            request.AddQueryParameter("refresh_token", token.Refresh_token);
            restClient.BaseUrl = new Uri(_googleSettings.token_uri);
            var response = restClient.Post(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JObject.Parse(response.Content).ToObject<GoogleAccessTokenEntityModel>();
            }
            return null;
        }


        public async Task<bool> DeleteAsync(GoogleAccessTokenEntityModel token)
        {
            RestRequest request = GetRequest();
            request.AddQueryParameter("token", token.Access_token);
            restClient.BaseUrl = new Uri(_googleSettings.token_revoke_uri);
            var response = restClient.Post(request);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
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
