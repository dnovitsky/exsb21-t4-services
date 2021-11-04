using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SAPex.Models;

namespace SAPex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<CreateCondidateViewModel> Get()
        {
            return new List<CreateCondidateViewModel>() { };
        }

        [HttpGet("{id}")]
        public CreateCondidateViewModel Get([FromRoute] Guid id)
        {
            return new CreateCondidateViewModel();
        }

        [HttpPost]
        public void Post([FromBody] CreateCondidateViewModel createCandidate)
        {
        }

        [HttpPut("{id}")]
        public void Put([FromRoute] Guid id, [FromBody] UpdateCondidateViewModel updateCandidateFields)
        {
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] Guid id)
        {
        }
    }
}
