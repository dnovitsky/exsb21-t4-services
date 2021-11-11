using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAPexAuthService.Services;

namespace SAPex.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly AuthUserService _authUserService;

        public UsersController(AuthUserService authUserService)
        {
            _authUserService = authUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var users = await _authUserService.FindAllAsync();
            return Ok(users);
        }
    }
}
