using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAPex.Models;

namespace SAPex
{
    [Route("api/languages")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        //---------------- Test LanguageModel ----
         private List<LanguageViewModel> storageList = new List<LanguageViewModel>() { };
        //-------------------------------

        [HttpGet]
        public async Task<IEnumerable<LanguageViewModel>> Get()
        {
            return await Task.FromResult(storageList.AsEnumerable<LanguageViewModel>());
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

        [HttpPost("{id}")]
        public async Task<IActionResult> Post([FromBody] LanguageViewModel language)
        {
            var oldCount = storageList.Count;
            storageList.Add(language);
            var newCount = storageList.Count;

            if (newCount > oldCount)
            {
                return await Task.FromResult(Ok());
            }

            return await Task.FromResult(NotFound());
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid Id, [FromBody] LanguageViewModel language)
        {
            LanguageViewModel item = storageList.Find(item => item.Id == Id);
            if (item != null)
            {
                return await Task.FromResult(Ok());
            }
            item.Name = language.Name;

            return await Task.FromResult(NotFound());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            LanguageViewModel item = storageList.Find(item => item.Id == Id);
            if (item != null)
            {
                return await Task.FromResult(Ok());
            }

            return await Task.FromResult(NotFound());
        }
    }
}
