using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAPex.Mappers;
using SAPex.Models;

namespace SAPex.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        protected readonly UserMapper _mapper = new UserMapper();
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("user-info")]
        public async Task<ActionResult<UserViewModel>> GetUserInfoAsync()
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var email = identity.FindFirst(ClaimTypes.Email).Value;
                var users = await _userService.FindUsersAsync(x => x.Email == email);
                return Ok(_mapper.MapUserFromDtoToView(users.FirstOrDefault()));
            }

            return NotFound();
        }
    }
}
