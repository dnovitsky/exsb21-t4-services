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
    }
}
