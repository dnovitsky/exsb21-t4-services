using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAPex.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAPex.Controllers
{
    [ApiController]
    public abstract class AbstractController<T> : ControllerBase where T : AbstractIdViewModel
    {
        protected List<T> storageList = new List<T>() { };
        protected FakeDBSingleton dB = new FakeDBSingleton();

        protected abstract int PostValidation(T requestData);
        protected abstract int PutValidation(Guid id, T requestData);

        protected Predicate<T> FindByIdCallback(Guid id)
        {
            return (item) => { return item.id == id; };
        }

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
            var statusCode = this.PostValidation(requestData);

            if (statusCode != 200)
            {
                return await Task.FromResult(StatusCode(statusCode));
            }

            await this.dB.setJsonData<T>(this.storageList);

            return await Task.FromResult(Ok("record has been added"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] T requestData)
        {
            var statusCode = this.PutValidation(id, requestData);

            if (statusCode != 200)
            {
                return await Task.FromResult(StatusCode(statusCode));
            }

            await this.dB.setJsonData<T>(this.storageList);

            return await Task.FromResult(Ok("record has been updated"));
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

            return await Task.FromResult(Ok("has been deleted"));
        }
    }
}
