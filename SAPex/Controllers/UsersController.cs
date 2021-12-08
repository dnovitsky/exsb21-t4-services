using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using DbMigrations.EntityModels.DataTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAPex.Mappers;
using SAPex.Models;
using SAPex.Models.EventModels;

namespace SAPex.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _autoMapper;
        private readonly IUserService _userService;
        private readonly IEventService _eventService;

        public UsersController(IUserService userService, IEventService eventService, IMapper autoMapper)
        {
            _autoMapper = autoMapper;
            _userService = userService;
            _eventService = eventService;
        }

        [HttpGet("user-info")]
        public async Task<ActionResult<UserViewModel>> GetUserInfoAsync()
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var email = identity.FindFirst(ClaimTypes.Email).Value;
                var users = await _userService.FindUsersAsync(x => x.Email == email);
                return Ok(_autoMapper.Map<UserViewModel>(users.FirstOrDefault()));
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            UserDtoModel user = await _userService.FindByIdAsync(id);

            if (user != null)
            {
                return await Task.FromResult(Ok(_autoMapper.Map<UserViewModel>(user)));
            }

            return await Task.FromResult(NotFound());
        }

        [HttpGet("{id}/events")]
        public async Task<IEnumerable<InterviewEventViewModel>> GetEventsByUserIdAsync(Guid id)
        {
            var events = await _eventService.GetAllByUserIdAsync(id);
            return _autoMapper.Map<IEnumerable<InterviewEventViewModel>>(events);
        }

        [HttpGet("{id}/events/filter")]
        public async Task<IEnumerable<InterviewEventViewModel>> GetUserEventsFilterAsync(Guid id, DateTime start, DateTime end, EventType type)
        {
            var events = await _eventService.GetAllUserFilterAsync(id, start, end, type);
            return _autoMapper.Map<IEnumerable<InterviewEventViewModel>>(events);
        }
    }
}
