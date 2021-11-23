using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SAPexAuthService.Services.Google;

namespace SAPex.Controllers.Authorization
{
    [Route("/api/google/authorization")]
    [ApiController]
    public class GoogleAuthorizationController : ControllerBase
    {
        private readonly GoogleOAuthService _googleOAuthService;

        public GoogleAuthorizationController(GoogleOAuthService googleOAuthService)
        {
            _googleOAuthService = googleOAuthService;
        }

        [HttpGet]
        public ActionResult OauthRedirect()
        {
            return Redirect(_googleOAuthService.GetRedirectUrl("test"));
        }

        [HttpGet("callback")]
        public async Task<ActionResult> CallBackAsync(string code, string error, string state)
        {
            var tokens = await _googleOAuthService.AddAsync(code);
            if (string.IsNullOrWhiteSpace(error) && tokens != null)
            {
                return Ok(tokens);
            }

            return BadRequest();
        }
    }
}
