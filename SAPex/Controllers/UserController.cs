using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAPex.Services;

namespace SAPex.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var email = string.Empty;
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                email = identity.FindFirst(ClaimTypes.Email).Value;
            }
            return Ok(_userService.FindByEmail(email));
        }

        [HttpGet("all")]
        [Authorize(Roles = "MANAGER")]
        public IActionResult GetAll()
        {
            return Ok(_userService.FindAll());
        }
    }
}
