
using Microsoft.AspNetCore.Mvc;
using SAPex.Models.Authorization;
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

        [HttpPost("authenticate")]
        public ActionResult<AuthenticateResponse> Authenticate([FromBody] AuthenticateRequest credentials)
        {
            var user = _jwtService.Authenticate(credentials.Email, credentials.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}
