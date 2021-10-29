using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAPex.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace SAPex
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {

        //---------------- Test SkillModel ----
        private List<SkillViewModel> storageList = new List<SkillViewModel>() { };
        //-------------------------------


        [HttpGet]
        public async Task<IEnumerable<SkillViewModel>> Get()
        {
            return await Task.FromResult(storageList.AsEnumerable<SkillViewModel>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            var item = storageList.Find(item => item.Id == Id);
            if (item == null)
            {
                return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(item));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SkillViewModel skill)
        {
            var oldCount = storageList.Count;
            storageList.Add(skill);
            var newCount = storageList.Count;

            if (newCount > oldCount)
            {
                return await Task.FromResult(Ok());
            }

            return await Task.FromResult(NotFound());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid Id, [FromBody] SkillViewModel skill)
        {
            SkillViewModel item = storageList.Find(item => item.Id == Id);
            if (item != null)
            {
                return await Task.FromResult(Ok());
            }
            item.Name = skill.Name;

            return await Task.FromResult(NotFound());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            SkillViewModel item = storageList.Find(item => item.Id == Id);
            if (item != null)
            {
                return await Task.FromResult(Ok());
            }

            return await Task.FromResult(NotFound());
        }
    }
}
