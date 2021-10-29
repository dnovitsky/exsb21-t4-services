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
    public abstract class AbstractController<T>: ControllerBase where T: AbstractIdViewModel
    {
        protected List<T> storageList = new List<T>() { };

        [HttpGet]
        public async Task<IEnumerable<T>> Get() {
            return await Task.FromResult(storageList.AsEnumerable<T>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid Id) {
            var response = this.storageList.Find(item => item.Id == Id);

            if (response == null)
            {
                return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(response));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T status) {
            storageList.Add(status);

            var response = this.storageList.Find(item => item.Id == status.Id);

            if (response == null) {
                return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid Id, [FromBody] T status) {
            var response = this.storageList.Find(item => item.Id == Id);

            if (response == null) {
                return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid Id) {
            var response = this.storageList.Find(item => item.Id == Id);

            if (response == null) {
                return await Task.FromResult(NotFound());
            }

            this.storageList.Remove(response);

            return await Task.FromResult(Ok());
        }
    }
}
