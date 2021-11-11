using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SAPex.Controllers
{
    /* TODO: please review and refactor this conrollers


    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService service)
        {
            _skillService = service;
        }

        // GET: api/<SkillController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SkillController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SkillController>
        [HttpPost]
        public async Task<Guid> Post([FromBody] string value)
        {
            SkillDtoModel skillDto = new SkillDtoModel { Name = value };
            SkillDtoModel newSkillDto = await _skillService.AddSkillAsync(skillDto);
            return newSkillDto.Id;
        }

        // PUT api/<SkillController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SkillController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    */
}
