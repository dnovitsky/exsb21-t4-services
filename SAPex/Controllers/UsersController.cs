﻿using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
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
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<UserDtoModel>> GetAsync()
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var email = identity.FindFirst(ClaimTypes.Email).Value;
                var users = await _userService.FindUsersAsync(x => x.Email == email);
                return Ok(users.FirstOrDefault());
            }

            return NotFound();
        }
    }
}
