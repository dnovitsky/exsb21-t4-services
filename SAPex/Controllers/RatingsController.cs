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
        protected override Predicate<RatingViewModel> FindByRequestDataCallback(RatingViewModel requestData)
        {
            return (item) => { return item.id == requestData.id; };
        }
    }
}
