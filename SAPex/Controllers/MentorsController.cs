using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SAPex.Mappers;
using SAPex.Models;

namespace SAPex.Controllers
{
    [Route("api/mentors")]
    [ApiController]
    public class MentorsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly MentorMapper _mapper = new ();

        public MentorsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMentors()
        {
            IEnumerable<UserDtoModel> mentorsDtoList = await _userService.FindAllByConditionAsync(s => s.FunctionalRole.Name == "Mentor");
            IList<MentorViewModel> mentorVMList = new List<MentorViewModel>();

            foreach (var mentor in mentorsDtoList)
            {
                mentorVMList.Add(_mapper.MapMentorFromDtoToView(mentor));
            }

            return await Task.FromResult(Ok(mentorVMList));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMentorById(Guid id)
        {
            UserDtoModel mentorDto = await _userService.FindByIdConditionAsync(s => s.FunctionalRole.Name == "Mentor" && s.UserId == id);

            if (mentorDto == null)
            {
                return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(_mapper.MapMentorFromDtoToView(mentorDto)));
        }
    }
}
