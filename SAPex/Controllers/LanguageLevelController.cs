﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAPex.Models;

namespace SAPex
{
    [Route("api/languagelevels")]
    [ApiController]
    public class LanguageLevelController : ControllerBase
    {
        //---------------- Test LanguageLevelModel ----
        private List<LanguageLevelViewModel> storageList = new List<LanguageLevelViewModel>() { };
        //-------------------------------

        [HttpGet]
        public async Task<IEnumerable<LanguageLevelViewModel>> Get()
        {
            return await Task.FromResult(storageList.AsEnumerable<LanguageLevelViewModel>());
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
        public async Task<IActionResult> Post([FromBody] LanguageLevelViewModel languageLevel)
        {
            var oldCount = storageList.Count;
            storageList.Add(languageLevel);
            var newCount = storageList.Count;

            if (newCount > oldCount)
            {
                return await Task.FromResult(Ok());
            }

            return await Task.FromResult(NotFound());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid Id, [FromBody] LanguageLevelViewModel languageLevel)
        {
            LanguageLevelViewModel item = storageList.Find(item => item.Id == Id);
            if (item != null)
            {
                return await Task.FromResult(Ok());
            }
            item.Name = languageLevel.Name;

            return await Task.FromResult(NotFound());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            LanguageLevelViewModel item = storageList.Find(item => item.Id == Id);
            if (item != null)
            {
                return await Task.FromResult(Ok());
            }

            return await Task.FromResult(NotFound());
        }
    }
}
