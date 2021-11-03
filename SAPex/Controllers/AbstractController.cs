using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAPex.Models;

namespace SAPex.Controllers
{
    [ApiController]
    public abstract class AbstractController<T> : ControllerBase where T : AbstractIdViewModel
    {
        protected List<T> storageList = new List<T>() { };
        protected FakeDBSingleton dB = new FakeDBSingleton();

        protected abstract IActionResult PostValidation(T requestData);
        protected abstract IActionResult PutValidation(Guid id, T requestData);

        protected Predicate<T> FindByIdCallback(Guid id)
        {
            return (item) => { return item.Id == id; };
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
        public async Task<IActionResult> Get([FromRoute] Guid id)
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
            IActionResult status = this.PostValidation(requestData);

            if (status is OkResult)
            {
                await this.dB.setJsonData<T>(this.storageList);
            }

            return await Task.FromResult(status);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] T requestData)
        {
            IActionResult status = this.PutValidation(id, requestData);

            if (status is OkResult)
            {
                await this.dB.setJsonData<T>(this.storageList);
            }

            return await Task.FromResult(status);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
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
