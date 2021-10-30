
using Microsoft.AspNetCore.Mvc;
using SAPex.Models.Authorization;

using SAPex.Services.Jwt;

namespace SAPex.Controllers.Authorization
{
    [Route("/authorization")]
    [ApiController]
    public class CustomAuthorizationController: ControllerBase
    {
        private readonly JwtService _userService;

        public CustomAuthorizationController(JwtService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCredentials credentials)
        {
            var user = _userService.Authenticate(credentials.Email, credentials.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}
