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
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly SkillMapper _mapper = new SkillMapper();

        public SkillsController(ISkillService service)
        {
            _skillService = service;
        }

        [HttpGet]
        public async Task<IEnumerable<SkillViewModel>> GetAllSkills()
        {
            return _mapper.MapListSkillFromDtoToView(await _skillService.GetAllSkillsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            SkillDtoModel skillDto = await _skillService.FindSkillByIdAsync(id);

            if (skillDto == null)
            {
                return await Task.FromResult(NotFound());
            }

            SkillViewModel skillVM = _mapper.MapSkillFromDtoToView(skillDto);
            return await Task.FromResult(Ok(skillVM));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SkillViewModel skillVM)
        {
            if (skillVM == null)
            {
                return await Task.FromResult(BadRequest());
            }

            ValidationResult validationResult = new SkillValidator().Validate(skillVM);

            if (!validationResult.IsValid)
            {
                return await Task.FromResult(BadRequest());
            }

            SkillDtoModel skillDto = _mapper.MapSkillFromViewToDto(skillVM);
            SkillDtoModel newSkillDto = await _skillService.AddSkillAsync(skillDto);
            return await Task.FromResult(Ok(newSkillDto.Id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] SkillViewModel skillVM)
        {
            SkillDtoModel skillDtoCheck = await _skillService.FindSkillByIdAsync(id);

            if (skillDtoCheck == null)
            {
                return await Task.FromResult(NotFound());
            }

            if (skillVM == null)
            {
                return await Task.FromResult(BadRequest());
            }

            ValidationResult validationResult = new SkillValidator().Validate(skillVM);

            if (!validationResult.IsValid)
            {
                return await Task.FromResult(BadRequest());
            }

            SkillDtoModel skillDto = _mapper.MapSkillFromViewToDto(skillVM);
            bool updateResult = await _skillService.UpdateSkill(skillDto);
            return await Task.FromResult(Ok("Was Updated"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(Guid id)
        {
            SkillDtoModel skillDto = await _skillService.FindSkillByIdAsync(id);

            if (skillDto == null)
            {
                return await Task.FromResult(NotFound());
            }

            await _skillService.DeleteSkill(id);
            return await Task.FromResult(Ok());
        }
    }
}
