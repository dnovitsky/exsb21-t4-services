using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SAPexAuthService.Services;

namespace SAPex.Controllers.Authorization
{
    [Route("/api/google/authorization")]
    [ApiController]
    public class GoogleAuthorizationController : ControllerBase
    {
        private readonly JwtService _authService;

        public GoogleAuthorizationController(JwtService authService)
        {
           _authService = authService;
        }

        [HttpGet]
        public ActionResult OauthRedirect()
        {
            return Redirect(url: _authService.GetGoogleUrl("test"));
        }

        [HttpGet("callback")]
        public async Task<ActionResult> CallBackAsync(string code, string error, string state)
        {
            var tokens = await _authService.GoogleAuthenticateAsync(code, state);
            if (string.IsNullOrWhiteSpace(error) && tokens != null)
            {
                return Ok(tokens);
            }

            return BadRequest();
        }
    }
}
