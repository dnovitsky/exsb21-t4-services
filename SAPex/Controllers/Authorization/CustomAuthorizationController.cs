
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAPex.Models;
using SAPex.Models.Authorization.AuthRequest;
using SAPex.Models.Authorization.AuthResponse;
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

        [HttpPost("signin")]
        public ActionResult<AuthenticateResponse> Authenticate([FromBody] AuthenticateRequest credentials)
        {
            var authResponse = _jwtService.Authenticate(credentials);
            if (authResponse != null)
            {
                return Ok(authResponse);
            }
            return Unauthorized();
        }

        [HttpPost("refresh-token")]
         public ActionResult<ActionResponse<AuthenticateResponse>> RefreshToken([FromBody] TokenRequest tokenRequest)
        {
            var authResponse = _jwtService.VerifyAndRefreshToken(tokenRequest);
            if (authResponse != null)
            {
                return Ok(authResponse);
            }
            return Unauthorized();
        }

        [Authorize]
        [HttpGet("signout/{refreshToken}")]
        public ActionResult<ActionResponse<AuthenticateResponse>> RevokeToken(string refreshToken)
        {
            if (_jwtService.RevokeToken(refreshToken))
            {
                return Ok();
            }
            return Unauthorized();
        }
    }
}
