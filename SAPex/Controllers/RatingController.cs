using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAPex
{
    [Route("api/ratings")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        //---------------- Test RatingModel ----
        public class RatingModel
        {
            public int id;
            public int name;
        }
        private List<RatingModel> storageList;
        //-------------------------------

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return storageList.Select(item => item.ToString()).AsEnumerable<string>();
        }

        [HttpGet]
        public string Get(int id)
        {
            return storageList.Find(item => item.id == id).ToString();
        }

        [HttpPost]
        public void Post([FromBody] RatingModel rating)
        {
            storageList.Add(rating);
        }

        [HttpPut]
        public void Put([FromBody] RatingModel rating)
        {
            RatingModel item = storageList.Find(item => item.id == rating.id);
            item.name = rating.name;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            RatingModel item = storageList.Find(item => item.id == id);
            storageList.Remove(item);
        }
    }
}
