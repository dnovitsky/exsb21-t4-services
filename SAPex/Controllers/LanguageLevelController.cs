using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAPex
{
    [Route("api/language_levels")]
    [ApiController]
    public class LanguageLevelController : ControllerBase
    {
        //---------------- Test LanguageLevelModel ----
        public class LanguageLevelModel
        {
            public int id;
            public int name;
        }
        private List<LanguageLevelModel> storageList;
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
        public void Post([FromBody] LanguageLevelModel languageLevel)
        {
            storageList.Add(languageLevel);
        }

        [HttpPut]
        public void Put([FromBody] LanguageLevelModel languageLevel)
        {
            LanguageLevelModel item = storageList.Find(item => item.id == languageLevel.id);
            item.name = languageLevel.name;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            LanguageLevelModel item = storageList.Find(item => item.id == id);
            storageList.Remove(item);
        }
    }
}
