using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAPex.Models;
using SAPex.Controllers;

namespace SAPex
{
    [Route("api/ratings")]
    [ApiController]
    public class RatingsController : AbstractController<RatingViewModel>
    {
        public RatingsController()
        {
            this.storageList = new List<RatingViewModel>() {
                new RatingViewModel(Guid.NewGuid(), 10, Guid.NewGuid()),
                new RatingViewModel(Guid.NewGuid(), 2, Guid.NewGuid()),
                new RatingViewModel(Guid.NewGuid(), 33, Guid.NewGuid()),
                new RatingViewModel(Guid.NewGuid(), 5, Guid.NewGuid())
            };
        }
    }
}
