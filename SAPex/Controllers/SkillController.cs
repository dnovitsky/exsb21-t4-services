using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace SAPex
{
    [Route("api/skills")]
    [ApiController]
    public class SkillController : ControllerBase
    {

        //---------------- Test SkillModel ----
        public class SkillModel
        {
            public int id;
            public int name;
        }
        private List<SkillModel> storageList;
        //-------------------------------


        [HttpGet]
        public IEnumerable<string> Get()
        {
            return storageList.Select(item => item.ToString()).AsEnumerable<string>();
        }

        [HttpGet]
        public string Get(int id)
        {
            return storageList.Find(item => item.id == id).ToString();
        }

        [HttpPost]
        public void Post([FromBody] SkillModel skill)
        {
            storageList.Add(skill);
        }

        [HttpPut]
        public void Put([FromBody] SkillModel skill)
        {
            SkillModel item = storageList.Find(item => item.id == skill.id);
            item.name = skill.name;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            SkillModel item = storageList.Find(item => item.id == id);
            storageList.Remove(item);
        }
    }
}
