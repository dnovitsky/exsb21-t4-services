using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace SAPex
{
    [Route("api/functional_roles")]
    [ApiController]
    public class FunctionalRoleController : ControllerBase
    {
        //---------------- Test FunctionalRoleModel ----
        public class FunctionalRoleModel
        {
            public int id;
            public int name;
        }
        private List<FunctionalRoleModel> storageList;
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
        public void Post([FromBody] FunctionalRoleModel functionalRole)
        {
            storageList.Add(functionalRole);
        }

        [HttpPut]
        public void Put([FromBody] FunctionalRoleModel functionalRole)
        {
            FunctionalRoleModel item = storageList.Find(item => item.id == functionalRole.id);
            item.name = functionalRole.name;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            FunctionalRoleModel item = storageList.Find(item => item.id == id);
            storageList.Remove(item);
        }
    }
}
