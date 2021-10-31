using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAPex.Models;
// using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAPex.Controllers
{
    [ApiController]
    public abstract class AbstractController<T> : ControllerBase where T : AbstractIdViewModel
    {
        protected List<T> storageList = new List<T>() { };
        protected FakeDBSingleton DB = new FakeDBSingleton();

        public AbstractController()
        {
            this.storageList = this.DB.getJsonData_Sync<T>();
        }

        [HttpGet]
        public async Task<IEnumerable<T>> Get()
        {
            return await Task.FromResult(this.storageList.AsEnumerable<T>());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            var response = this.storageList.Find(item => item.Id == Id);

            if (response == null)
            {
                return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(response));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T status)
        {
            this.storageList.Add(status);

            var response = this.storageList.Find(item => item.Id == status.Id);

            if (response == null)
            {
                return await Task.FromResult(NotFound());
            }

            await this.DB.setJsonData<T>(this.storageList);

            return await Task.FromResult(Ok());
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(Guid Id, [FromBody] T status)
        {
            var index = this.storageList.IndexOf(this.storageList.Find(item => item.Id == Id));

            if (index < 0)
            {
                return await Task.FromResult(NotFound());
            }

            this.storageList[index] = status;
            await this.DB.setJsonData<T>(this.storageList);

            return await Task.FromResult(Ok());
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var response = this.storageList.Find(item => item.Id == Id);

            if (response == null)
            {
                return await Task.FromResult(NotFound());
            }

            this.storageList.Remove(response);
            await this.DB.setJsonData<T>(this.storageList);

            return await Task.FromResult(Ok());
        }
    }
}
