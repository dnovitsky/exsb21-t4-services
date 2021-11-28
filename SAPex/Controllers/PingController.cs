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

        [HttpGet("mentor")]
        [Authorize(Roles = "Mentor")]
        public ActionResult GetMentor()
        {
            return Ok();
        }

        [HttpGet("interviewer")]
        [Authorize(Roles = "Interviewer")]
        public ActionResult GetInterviewer()
        {
            return Ok();
        }

        [HttpGet("recruiter")]
        [Authorize(Roles = "Recruiter")]
        public ActionResult GetRecruiter()
        {
            return Ok();
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetAdmin()
        {
            return Ok();
        }

        [HttpGet("edumanager")]
        [Authorize(Roles = "EDU manager")]
        public ActionResult GetEduManager()
        {
            return Ok();
        }
    }
}
