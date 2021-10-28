using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAPex
{
    [Route("api/statuses")]
    [ApiController]
    public class StatuseController : ControllerBase
    {
        //---------------- Test StatusesModel ----
        public class StatusesModel
        {
            public int id;
            public int name;
        }
        private List<StatusesModel> storageList;
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
        public void Post([FromBody] StatusesModel status)
        {
            storageList.Add(status);
        }

        [HttpPut]
        public void Put([FromBody] StatusesModel status)
        {
            StatusesModel item = storageList.Find(item => item.id == status.id);
            item.name = status.name;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            StatusesModel item = storageList.Find(item => item.id == id);
            storageList.Remove(item);
        }
    }
}
