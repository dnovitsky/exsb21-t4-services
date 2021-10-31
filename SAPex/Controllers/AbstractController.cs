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
        protected FakeDBSingleton dB = new FakeDBSingleton();

        protected Predicate<T> FindByIdCallback(Guid id) {
            return (item) => { return item.id == id; };
        }

        protected abstract Predicate<T> FindByRequestDataCallback(T requestData);

        public AbstractController()
        {
            this.storageList = this.dB.getJsonData_Sync<T>();
        }

        [HttpGet]
        public async Task<IEnumerable<T>> Get()
        {
            return await Task.FromResult(this.storageList.AsEnumerable<T>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = this.storageList.Find(this.FindByIdCallback(id));

            if (response == null)
            {
                return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(response));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T requestData)
        {
            var response = this.storageList.Find(this.FindByRequestDataCallback(requestData));

            if (response != null)
            {
                return await Task.FromResult(StatusCode(403));
            }

            this.storageList.Add(requestData);
            await this.dB.setJsonData<T>(this.storageList);

            return await Task.FromResult(Ok());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] T requestData)
        {
            var index = this.storageList.IndexOf(this.storageList.Find(this.FindByIdCallback(id)));

            if (index < 0)
            {
                return await Task.FromResult(NotFound());
            }

            this.storageList[index] = requestData;
            await this.dB.setJsonData<T>(this.storageList);

            return await Task.FromResult(Ok());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = this.storageList.Find(this.FindByIdCallback(id));

            if (response == null)
            {
                return await Task.FromResult(NotFound());
            }

            this.storageList.Remove(response);
            await this.dB.setJsonData<T>(this.storageList);

            return await Task.FromResult(Ok());
        }
    }
}
