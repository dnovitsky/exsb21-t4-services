using Microsoft.AspNetCore.Mvc;
using SAPex.Models;
using SAPex.Controllers;

namespace SAPex
{
    [Route("api/statuses")]
    [ApiController]
    public class StatusesController : AbstractNameController<StatusViewModel>
    {
    }
}
