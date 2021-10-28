
using Microsoft.AspNetCore.Mvc;
using SAPex.Models.Authorization;
using SAPex.Services.Google.IGoogleSevices;
using SAPex.Services.Jwt;

namespace SAPex.Controllers
{
    [Route("/oauth")]
    [ApiController]
    public class OauthController : ControllerBase
    {
        private readonly IGoogleOAuthService googleOAuthService;
        private readonly JwtService jwtService;

        public OauthController(IGoogleOAuthService googleOAuthService,JwtService jwtService)
        {
            this.googleOAuthService = googleOAuthService;
            this.jwtService = jwtService;
        }

        [HttpGet("{email}")]
        public IActionResult OauthRedirect([FromRoute] string email)
        {
            return Redirect(googleOAuthService.GetRedirectUrl(email));   
        }

        [HttpGet("callback")]
        public IActionResult CallBack(string code,string error,string state)
        { 
            if (string.IsNullOrWhiteSpace(error) && googleOAuthService.Add(code, state) != null)
            {
                return Ok(googleOAuthService.GetUserInfo(state));
            }
            return BadRequest();
        }

        [HttpGet("userinfo/{email}")]
        public IActionResult GetUserInfo([FromRoute] string email) {
            return Ok(googleOAuthService.GetUserInfo(email));
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCredentials credentials)
        {
            string userToken = jwtService.Authenticate(credentials.Email, credentials.Password);
            if (userToken != null)
            {
                return Ok(userToken);
            }
            return BadRequest();
        }    

        
    }
}
