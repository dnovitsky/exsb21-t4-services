
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
        public ActionResult OauthRedirect(string email)
        {
            return Redirect(googleOAuthService.GetRedirectUrl(email));   
        }

        [HttpGet("callback")]
        public ActionResult CallBack(string code,string error,string state)
        { 
            if (string.IsNullOrWhiteSpace(error) && googleOAuthService.Add(code, state) != null)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
