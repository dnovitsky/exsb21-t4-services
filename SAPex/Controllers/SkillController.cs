using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Service;
using DbMigrations.Data;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SAPex.Mappers;
using SAPex.Models;
using SAPex.Models.Validators;

namespace SAPex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly SkillMapper _mapper = new SkillMapper();

        public SkillController(ISkillService service)
        {
            _skillService = service;
        }

        // GET: api/<SkillController>
        [HttpGet]
        public async Task<IEnumerable<SkillViewModel>> GetAllSkills()
        {
            return _mapper.MapListSkillFromDtoToView(await _skillService.GetAllSkillsAsync());
        }

        // GET api/<SkillController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            SkillDtoModel skillDto = await _skillService.FindSkillByIdAsync(id);
            SkillViewModel skillVM = _mapper.MapSkillFromDtoToView(skillDto);

            return await Task.FromResult(Ok(skillVM));
        }

        // POST api/<SkillController>
        [HttpPost]
        public async Task<Guid> Post([FromBody] SkillViewModel skillVM)
        {
            SkillDtoModel skillDto = _mapper.MapSkillFromViewToDto(skillVM);
            SkillDtoModel newSkillDto = await _skillService.AddSkillAsync(skillDto);
            return newSkillDto.Id;
        }

        // PUT api/<SkillController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] SkillViewModel skillVM)
        {
            SkillDtoModel skillDto = _mapper.MapSkillFromViewToDto(skillVM);
            bool updateResult = await _skillService.UpdateSkill(skillDto);

            if (updateResult)
            {
                return await Task.FromResult(Ok("Was Update"));
            }
            else
            {
                return await Task.FromResult(Ok("Wasn't Update"));
            }
        }

        // DELETE api/<SkillController>/5
        [HttpDelete("{id}")]
        public async Task DeleteSkill(Guid id)
        {
            await _skillService.DeleteSkill(id);
        }
    }
}
