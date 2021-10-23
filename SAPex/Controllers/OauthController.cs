using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp;
using SAPex.Models;
using SAPex.Models.Google;

namespace SAPex.Controllers
{
    [Route("/oauth")]
    [ApiController]
    public class OauthController : ControllerBase
    {

        private const string GOOGLE_TOKEN_PATH = @"GoogleFiles/tokens.json";
        private readonly RestClient restClient = new();
        private readonly RestRequest request = new();
        private readonly string GOOGLE_CLIENT_ID;
        private readonly string GOOGLE_CLIENT_SECRET;
        private readonly string GOOGLE_AUTHENTICATION_URL;
        private readonly string GOOGLE_AUTHENTICATION_TOKEN_URL;
        private readonly string GOOGLE_AUTHENTICATION_TOKEN_REVOKE_URL;
        private readonly string GOOGLE_REDIRECT_URL;

        public OauthController(IConfiguration configuration) {
            GOOGLE_CLIENT_ID = configuration.GetSection("GoogleStrings").GetSection("client_id").Value;
            GOOGLE_CLIENT_SECRET = configuration.GetSection("GoogleStrings").GetSection("client_secret").Value;
            GOOGLE_AUTHENTICATION_URL = configuration.GetSection("GoogleStrings").GetSection("auth_uri").Value;
            GOOGLE_AUTHENTICATION_TOKEN_URL = configuration.GetSection("GoogleStrings").GetSection("token_uri").Value;
            GOOGLE_AUTHENTICATION_TOKEN_REVOKE_URL= configuration.GetSection("GoogleStrings").GetSection("token_revoke_uri").Value;
            GOOGLE_REDIRECT_URL = configuration.GetSection("GoogleStrings").GetSection("redirect_uris").Value;

        }

        [HttpGet("{email}")]
        public ActionResult OauthRedirect(string email)
        {
            var redirectUrl = GOOGLE_AUTHENTICATION_URL +
               "?scope=" + String.Format("{0}+{1}+{2}+{3}",
                                            GoogleScope.CALENDAR,
                                            GoogleScope.CALENDAR_READ_ONLY,
                                            GoogleScope.EVENTS,
                                            GoogleScope.EVENTS_READ_ONLY) +
                "&access_type=offline" +
                "&include_granted_scopes=true" +
                "&response_type=code" +
                "&state=" + email +
                "&redirect_uri="+ GOOGLE_REDIRECT_URL +
                "&client_id=" + GOOGLE_CLIENT_ID;
            return Redirect(redirectUrl);
        }

        [HttpGet("callback")]
        public ActionResult<GoogleUserAccessToken> CallBack(string code,string error,string state) {
            if (string.IsNullOrWhiteSpace(error)) {
                return GetTokens(code,state);
            }
            return BadRequest();
        }

        private ActionResult<GoogleUserAccessToken> GetTokens(string code,string email)
        {
            request.AddQueryParameter("client_id", GOOGLE_CLIENT_ID);
            request.AddQueryParameter("client_secret", GOOGLE_CLIENT_SECRET);
            request.AddQueryParameter("code", code);
            request.AddQueryParameter("grant_type", "authorization_code");
            request.AddQueryParameter("redirect_uri", GOOGLE_REDIRECT_URL);

            restClient.BaseUrl = new System.Uri(GOOGLE_AUTHENTICATION_TOKEN_URL);
            var response = restClient.Post(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject events = JObject.Parse(response.Content);
                GoogleUserAccessToken token = events.ToObject<GoogleUserAccessToken>();
                token.Email = email;
                System.IO.File.WriteAllText(GOOGLE_TOKEN_PATH, response.Content);
                return token;
            }
            return BadRequest();

        }
        [HttpGet("refresh")]
        public ActionResult RefreshTokens()
        {
            var tokens = JObject.Parse(System.IO.File.ReadAllText(GOOGLE_TOKEN_PATH));
            request.AddQueryParameter("client_id", GOOGLE_CLIENT_ID);
            request.AddQueryParameter("client_secret", GOOGLE_CLIENT_SECRET);
            request.AddQueryParameter("grant_type", "refresh_token");
            request.AddQueryParameter("refresh_token", tokens["refresh_token"].ToString());

            restClient.BaseUrl = new System.Uri(GOOGLE_AUTHENTICATION_TOKEN_URL);
            var response = restClient.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject refreshedTokens = JObject.Parse(response.Content);
                refreshedTokens["refresh_token"] = tokens["refresh_token"].ToString();
                System.IO.File.WriteAllText(GOOGLE_TOKEN_PATH, refreshedTokens.ToString());
                return Ok();
            }
            return BadRequest();

        }
        [HttpGet("revoke")]
        public ActionResult RevokeTokens()
        {
            var tokens = JObject.Parse(System.IO.File.ReadAllText(GOOGLE_TOKEN_PATH));

            request.AddQueryParameter("token", tokens["access_token"].ToString());
            
            restClient.BaseUrl = new System.Uri(GOOGLE_AUTHENTICATION_TOKEN_REVOKE_URL);
            var response = restClient.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                 return Ok();
            }
            return BadRequest();

        }
    }
}
