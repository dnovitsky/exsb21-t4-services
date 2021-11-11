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
        private readonly JwtService _jwtService;

        public CustomAuthorizationController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("sign-in")]
        public async Task<ActionResult<TokenCredentialsModel>> AuthenticateAsync([FromBody] UserCredentialsModel credentials)
        {
            var authResponse = await _jwtService.AuthenticateAsync(credentials);
            if (authResponse != null)
            {
                return Ok(authResponse);
            }

            return Unauthorized();
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenCredentialsModel>> RefreshTokenAsync([FromBody] TokenCredentialsModel tokenRequest)
        {
            var authResponse = await _jwtService.VerifyAndRefreshTokenAsync(tokenRequest);
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
            if (await _jwtService.RevokeTokenAsync(refreshToken))
            {
                return Ok();
            }

            return Unauthorized();
        }
    }
}
