using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAPexAuthService.Models;
using SAPexAuthService.Services;

namespace SAPex.Controllers.Authorization
{
    [Route("/api/authorization")]
    [ApiController]
    public class CustomAuthorizationController : ControllerBase
    {
        private readonly AuthService _authService;

        public CustomAuthorizationController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("sign-in")]
        public async Task<ActionResult<TokenCredentialsModel>> AuthenticateAsync([FromBody] UserCredentialsModel credentials)
        {
            var authResponse = await _authService.AuthenticateAsync(credentials);
            if (authResponse != null)
            {
                return Ok(authResponse);
            }

            return Unauthorized();
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenCredentialsModel>> RefreshTokenAsync([FromBody] TokenCredentialsModel tokenRequest)
        {
            var authResponse = await _authService.VerifyAndRefreshTokenAsync(tokenRequest);
            if (authResponse != null)
            {
                return Ok(authResponse);
            }

            return Unauthorized();
        }

        [Authorize]
        [HttpGet("sign-out/{refreshToken}")]
        public async Task<ActionResult> RevokeTokenAsync(string refreshToken)
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                await _authService.RevokeTokenAsync(identity.FindFirst(ClaimTypes.Email).Value);
                return Ok();
            }

            return Unauthorized();
        }
    }
}
