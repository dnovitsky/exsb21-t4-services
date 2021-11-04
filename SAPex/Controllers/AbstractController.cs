using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SAPex.Models;

namespace SAPex.Controllers
{
    [ApiController]
    public abstract class AbstractController<T> : ControllerBase
        where T : AbstractIdViewModel
    {
        protected List<T> storageList = new List<T>() { };
        protected FakeDBSingleton fakeDB = new FakeDBSingleton();

        protected abstract IActionResult PostValidation(T requestData);

        protected abstract IActionResult PutValidation(Guid id, T requestData);

        protected Predicate<T> FindByIdCallback(Guid id)
        {
            return (item) => { return item.Id == id; };
        }

        public AbstractController()
        {
            storageList = fakeDB.GetJsonData_Sync<T>();
        }

        [HttpGet]
        public async Task<IEnumerable<T>> Get()
        {
            return await Task.FromResult(storageList.AsEnumerable<T>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = storageList.Find(FindByIdCallback(id));

            if (response == null)
            {
                return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(response));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T requestData)
        {
            IActionResult status = PostValidation(requestData);

            if (status is OkObjectResult)
            {
                await fakeDB.SetJsonData<T>(storageList);
            }

            return await Task.FromResult(status);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] T requestData)
        {
            IActionResult status = PutValidation(id, requestData);

            if (status is OkObjectResult)
            {
                await fakeDB.SetJsonData<T>(storageList);
            }

            return await Task.FromResult(status);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = storageList.Find(FindByIdCallback(id));

            if (response == null)
            {
                return await Task.FromResult(NotFound());
            }

            storageList.Remove(response);
            await fakeDB.SetJsonData<T>(storageList);

            return await Task.FromResult(Ok("has been deleted"));
        }
    }
}
