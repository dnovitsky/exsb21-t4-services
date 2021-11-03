

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAPex.Models;
using SAPex.Models.Authorization;
using SAPex.Services.Jwt;

namespace SAPex.Controllers.Authorization
{
    [Route("/authorization")]
    [ApiController]
    public class CustomAuthorizationController: ControllerBase
    {
        private readonly JwtService _jwtService;

        public CustomAuthorizationController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("sign-in")] //sign-in
        public ActionResult<TokenCredentials> Authenticate([FromBody] UserCredentials credentials)
        {
            var authResponse = _jwtService.Authenticate(credentials);
            if (authResponse != null)
            {
                return Ok(authResponse);
            }
            return Unauthorized();
        }

        [HttpPost("refresh-token")]
         public ActionResult<TokenCredentials> RefreshToken([FromBody] TokenCredentials tokenRequest)
        {
            var authResponse = _jwtService.VerifyAndRefreshToken(tokenRequest);
            if (authResponse != null)
            {
                return Ok(authResponse);
            }
            return Unauthorized();
        }

        [Authorize]
        [HttpGet("sign-out/{refreshToken}")] //sign-out
        public ActionResult RevokeToken(string refreshToken)
        {
            if (_jwtService.RevokeToken(refreshToken))
            {
                return Ok();
            }
            return Unauthorized();
        }
    }
}
