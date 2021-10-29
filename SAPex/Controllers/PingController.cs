using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SAPex.Controllers
{
    [Route("api/ping")]
    [ApiController]     
    public class PingController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("admin")]
        public ActionResult GetAdmin()
        {
            return Ok();
        }
        [Authorize(Roles = "USER")]
        [HttpGet("user")]
        public ActionResult GetUser()
        {
            return Ok();
        }

    }
}
