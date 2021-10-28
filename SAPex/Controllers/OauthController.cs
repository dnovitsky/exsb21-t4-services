
using Microsoft.AspNetCore.Mvc;
using SAPex.Services.Google.IGoogleSevices;

namespace SAPex.Controllers
{
    [Route("/oauth")]
    [ApiController]
    public class OauthController : ControllerBase
    {
        private readonly IGoogleOAuthService googleOAuthService;

        public OauthController(IGoogleOAuthService googleOAuthService)
        {
            this.googleOAuthService = googleOAuthService;
        }

        [HttpGet("{email}")]
        public ActionResult OauthRedirect([FromRoute] string email)
        {
            return Redirect(googleOAuthService.GetRedirectUrl(email));   
        }

        [HttpGet("callback")]
        public ActionResult CallBack(string code,string error,string state)
        { 
            if (string.IsNullOrWhiteSpace(error) && googleOAuthService.Add(code, state) != null)
            {
                return Ok(googleOAuthService.GetUserInfo(state));
            }
            return BadRequest();
        }
        [HttpGet("userinfo/{email}")]
        public ActionResult GetUserInfo([FromRoute] string email) {
            return Ok(googleOAuthService.GetUserInfo(email));
        }

        
    }
}
