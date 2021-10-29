using System;
using Microsoft.AspNetCore.Mvc;
using SAPex.Models.Authorization;
using SAPex.Services.Google.IGoogleSevices;
using SAPex.Services.Jwt;

namespace SAPex.Controllers.Authorization
{
    [Route("/authorization")]
    [ApiController]
    public class AuthorizationController: ControllerBase
    {
        private readonly IGoogleOAuthService _googleOAuthService;
        private readonly JwtService _userService;

        public AuthorizationController(IGoogleOAuthService googleOAuthService, JwtService userService)
        {
            _googleOAuthService = googleOAuthService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult OauthRedirect()
        {
            return Redirect(_googleOAuthService.GetRedirectUrl());
        }

        [HttpGet("callback")]
        public IActionResult CallBack(string code, string error, string state)
        {
            if (string.IsNullOrWhiteSpace(error) && _googleOAuthService.Add(code, state) != null)
            {
                return Ok(_googleOAuthService.GetUserInfo(state));
            }
            return BadRequest();
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
