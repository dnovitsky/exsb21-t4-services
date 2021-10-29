using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using SAPex.Models;

namespace SAPex
{
    [Route("api/functionalroles")]
    [ApiController]
    public class FunctionalRolesController : ControllerBase
    {
        //---------------- Test FunctionalRoleModel ----
        private List<FunctionalRoleViewModel> storageList = new List<FunctionalRoleViewModel>() { };
        //-------------------------------

        [HttpGet]
        public async Task<IEnumerable<FunctionalRoleViewModel>> Get()
        {
            return await Task.FromResult(storageList.AsEnumerable<FunctionalRoleViewModel>());
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
        public async Task<IActionResult> Post([FromBody] FunctionalRoleViewModel functionalRole)
        {
            var oldCount = storageList.Count;
            storageList.Add(functionalRole);
            var newCount = storageList.Count;

            if (newCount > oldCount)
            {
                return await Task.FromResult(Ok());
            }

            return await Task.FromResult(NotFound());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid Id, [FromBody] FunctionalRoleViewModel functionalRole)
        {
            FunctionalRoleViewModel item = storageList.Find(item => item.Id == Id);
            if (item != null)
            {
                return await Task.FromResult(Ok());
            }
            item.Name = functionalRole.Name;
            item.Access = functionalRole.Access;

            return await Task.FromResult(NotFound());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            FunctionalRoleViewModel item = storageList.Find(item => item.Id == Id);
            if (item != null)
            {
                return await Task.FromResult(Ok());
            }

            return await Task.FromResult(NotFound());
        }
    }
}
