using System;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp;
using SAPex.Models;
using SAPex.Models.Google;
using SAPex.Repositories.Google.IGoogleRepositories;
using SAPex.Services.Google.IGoogleSevices;

namespace SAPex.Services.Google
{
    public class GoogleOAuthService : IGoogleOAuthService
    {
        private readonly RestClient restClient = new();
        private readonly string GOOGLE_CLIENT_ID;
        private readonly string GOOGLE_CLIENT_SECRET;
        private readonly string GOOGLE_AUTHENTICATION_URL;
        private readonly string GOOGLE_AUTHENTICATION_TOKEN_URL;
        private readonly string GOOGLE_AUTHENTICATION_TOKEN_REVOKE_URL;
        private readonly string GOOGLE_REDIRECT_URL;

        private readonly IGoogleUserAccessTokenRepository googleUserAccess;

        public GoogleOAuthService(IConfiguration configuration, IGoogleUserAccessTokenRepository googleUserAccess)
        {
            GOOGLE_CLIENT_ID = configuration.GetSection("GoogleStrings").GetSection("client_id").Value;
            GOOGLE_CLIENT_SECRET = configuration.GetSection("GoogleStrings").GetSection("client_secret").Value;
            GOOGLE_AUTHENTICATION_URL = configuration.GetSection("GoogleStrings").GetSection("auth_uri").Value;
            GOOGLE_AUTHENTICATION_TOKEN_URL = configuration.GetSection("GoogleStrings").GetSection("token_uri").Value;
            GOOGLE_AUTHENTICATION_TOKEN_REVOKE_URL = configuration.GetSection("GoogleStrings").GetSection("token_revoke_uri").Value;
            GOOGLE_REDIRECT_URL = configuration.GetSection("GoogleStrings").GetSection("redirect_uris").Value;
            this.googleUserAccess = googleUserAccess;
        }

        public string GetRedirectUrl(string email) {
            var scope = string.Format("{0}+{1}+{2}+{3}", GoogleScope.CALENDAR, GoogleScope.CALENDAR_READ_ONLY, GoogleScope.EVENTS, GoogleScope.EVENTS_READ_ONLY);
            return  $"{GOOGLE_AUTHENTICATION_URL}?scope={scope}&access_type=offline&include_granted_scopes=true&response_type=code&state={email}&redirect_uri={GOOGLE_REDIRECT_URL}&client_id={GOOGLE_CLIENT_ID}";
        }
       
        public GoogleUserAccessToken Add(string code, string email)
        {   
            RestRequest request = GetRequest();
            request.AddQueryParameter("code", code);
            request.AddQueryParameter("grant_type", "authorization_code");
            request.AddQueryParameter("redirect_uri", GOOGLE_REDIRECT_URL);
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            restClient.BaseUrl = new System.Uri(GOOGLE_AUTHENTICATION_TOKEN_URL);
            var response = restClient.Post(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject events = JObject.Parse(response.Content);
                GoogleUserAccessToken userAccess = events.ToObject<GoogleUserAccessToken>();
                userAccess.Set(email, now);
                return googleUserAccess.Add(userAccess); 
            }
            return null;
        }
        public GoogleUserAccessToken Update(string email)
        {
            var currentUserAccess = googleUserAccess.FindByEmail(email);
            RestRequest request = GetRequest();
            request.AddQueryParameter("grant_type", "refresh_token");
            request.AddQueryParameter("refresh_token", currentUserAccess.Refresh_token);
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            restClient.BaseUrl = new System.Uri(GOOGLE_AUTHENTICATION_TOKEN_URL);
            var response = restClient.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject jsonRefresh = JObject.Parse(response.Content);
                GoogleUserAccessToken refreshUserAccess = jsonRefresh.ToObject<GoogleUserAccessToken>();
                refreshUserAccess.Set(currentUserAccess.Id, email, currentUserAccess.Refresh_token, now);
                return googleUserAccess.Update(refreshUserAccess); 
            }
            return null;
        }

        public bool Delete(string email)
        {
            var tokens = googleUserAccess.FindByEmail(email);
            RestRequest request = GetRequest();
            request.AddQueryParameter("token", tokens.Access_token);
            restClient.BaseUrl = new System.Uri(GOOGLE_AUTHENTICATION_TOKEN_REVOKE_URL);
            var response = restClient.Post(request);
            return response.StatusCode == System.Net.HttpStatusCode.OK;

        }
       
        public GoogleUserAccessToken GetGoogleUserAccessToken(string email)
        {
            GoogleUserAccessToken userAccess = googleUserAccess.FindByEmail(email);
            long expires = userAccess.Created_in + (userAccess.Expires_in*1000);
            long now =  DateTimeOffset.Now.ToUnixTimeMilliseconds();
            if (expires >= now) {
                userAccess = Update(email);
            }
            return userAccess;

        }

        private RestRequest GetRequest()
        {
            RestRequest request = new();
            request.AddQueryParameter("client_id", GOOGLE_CLIENT_ID);
            request.AddQueryParameter("client_secret", GOOGLE_CLIENT_SECRET);
            return request;
        }
        
    }
}
