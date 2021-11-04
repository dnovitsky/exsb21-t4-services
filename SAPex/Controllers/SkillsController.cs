using Microsoft.AspNetCore.Mvc;
using SAPex.Controllers;
using SAPex.Models;

namespace SAPex
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : AbstractNameController<SkillViewModel>
    {
    }
}
