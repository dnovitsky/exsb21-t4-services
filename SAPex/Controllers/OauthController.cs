using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace SAPex.Controllers
{
    [Route("/oauth")]
    [ApiController]
    public class OauthController:ControllerBase
    {
        private const string GOOGLE_CLIENT_SECRET_PATH = @"/Users/mybook/Projects/SAPex/SAPex/GoogleFiles/client_secret.json";
        private const string GOOGLE_TOKEN_PATH = @"/Users/mybook/Projects/SAPex/SAPex/GoogleFiles/tokens.json";
        private readonly RestClient restClient = new();
        private readonly RestRequest request = new();
        private readonly JObject clientSecret;

        public OauthController() {
            clientSecret= JObject.Parse(System.IO.File.ReadAllText(GOOGLE_CLIENT_SECRET_PATH));
        }

        [HttpGet]
        public ActionResult OauthRedirect()
        {
            var client_id = clientSecret["client_id"];
            var redirectUrl = "https://accounts.google.com/o/oauth2/v2/auth?" +
                "scope=https://www.googleapis.com/auth/calendar+https://www.googleapis.com/auth/calendar.events+https://www.googleapis.com/auth/calendar.events.readonly+https://www.googleapis.com/auth/calendar.readonly&" +
                "access_type=offline&" +
                "include_granted_scopes=true&" +
                "response_type=code&" +
                "state=hellothere&" +
                "redirect_uri=https://localhost:5001/oauth/callback&" +
                "client_id=" + client_id;
            return Redirect(redirectUrl);
        }

        [HttpGet("callback")]
        public void CallBack(string code,string error,string state) {
            if (string.IsNullOrWhiteSpace(error)) {
                GetTokens(code);
            }
        }

        private ActionResult GetTokens(string code)
        {
            request.AddQueryParameter("client_id", clientSecret["client_id"].ToString());
            request.AddQueryParameter("client_secret", clientSecret["client_secret"].ToString());
            request.AddQueryParameter("code", code);
            request.AddQueryParameter("grant_type", "authorization_code");
            request.AddQueryParameter("redirect_uri", "https://localhost:5001/oauth/callback");

            restClient.BaseUrl = new System.Uri("https://oauth2.googleapis.com/token");
            var response = restClient.Post(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                System.IO.File.WriteAllText(GOOGLE_TOKEN_PATH, response.Content);
                return Ok();
            }
            return BadRequest();

        }
        [HttpGet("refresh")]
        public ActionResult RefreshTokens()
        {
            

            var clientSecret = JObject.Parse(System.IO.File.ReadAllText(GOOGLE_CLIENT_SECRET_PATH));
            var tokens = JObject.Parse(System.IO.File.ReadAllText(GOOGLE_TOKEN_PATH));
            request.AddQueryParameter("client_id", clientSecret["client_id"].ToString());
            request.AddQueryParameter("client_secret", clientSecret["client_secret"].ToString());
            request.AddQueryParameter("grant_type", "refresh_token");
            request.AddQueryParameter("refresh_token", tokens["refresh_token"].ToString());

            restClient.BaseUrl = new System.Uri("https://oauth2.googleapis.com/token");
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
            
            restClient.BaseUrl = new System.Uri("https://oauth2.googleapis.com/revoke");
            var response = restClient.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                 return Ok();
            }
            return BadRequest();

        }
    }
}
