using Microsoft.AspNetCore.Mvc;
using SAPex.Controllers;
using SAPex.Models;

namespace SAPex
{
    [Route("api/statuses")]
    [ApiController]
    public class StatusesController : AbstractNameController<StatusViewModel>
    {
    }
}
