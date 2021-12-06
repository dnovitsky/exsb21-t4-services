using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SAPex.Controllers
{
    [Route("api/testtasks")]
    [ApiController]
    public class TestTasksController : ControllerBase
    {
        [HttpGet("{token}")]
        public async Task<IActionResult> Get([FromRoute] string token)
        {
            return await Task.FromResult(Ok());
        }
    }
}
