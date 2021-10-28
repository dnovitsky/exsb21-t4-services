using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAPex
{
    [Route("api/languages")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        //---------------- Test LanguageModel ----
        public class LanguageModel
        {
            public int id;
            public int name;
        }
        private List<LanguageModel> storageList;
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
        public void Post([FromBody] LanguageModel language)
        {
            storageList.Add(language);
        }

        [HttpPut]
        public void Put([FromBody] LanguageModel language)
        {
            LanguageModel item = storageList.Find(item => item.id == language.id);
            item.name = language.name;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            LanguageModel item = storageList.Find(item => item.id == id);
            storageList.Remove(item);
        }
    }
}
