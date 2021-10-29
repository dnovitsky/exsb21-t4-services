using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAPex.Models;

namespace SAPex
{
    [Route("api/ratings")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        //---------------- Test RatingModel ----
        private List<RatingViewModel> storageList = new List<RatingViewModel>() { };
        //-------------------------------

        [HttpGet]
        public async Task<IEnumerable<RatingViewModel>> Get()
        {
            return await Task.FromResult(storageList.AsEnumerable<RatingViewModel>());
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
        public async Task<IActionResult> Post([FromBody] RatingViewModel rating)
        {
            var oldCount = storageList.Count;
            storageList.Add(rating);
            var newCount = storageList.Count;

            if (newCount > oldCount)
            {
                return await Task.FromResult(Ok());
            }

            return await Task.FromResult(NotFound());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid Id, [FromBody] RatingViewModel raiting)
        {
            RatingViewModel item = storageList.Find(item => item.Id == Id);
            if (item != null)
            {
                return await Task.FromResult(Ok());
            }
            item.Mark = raiting.Mark;
            item.SkillId = raiting.SkillId;

            return await Task.FromResult(NotFound());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            RatingViewModel item = storageList.Find(item => item.Id == Id);
            if (item != null)
            {
                return await Task.FromResult(Ok());
            }

            return await Task.FromResult(NotFound());
        }
    }
}
