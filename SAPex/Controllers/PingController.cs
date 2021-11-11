using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SAPex.Controllers
{
    [Route("api/ping")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "mentor")]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}
