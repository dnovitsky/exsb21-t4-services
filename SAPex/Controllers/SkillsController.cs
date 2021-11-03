using Microsoft.AspNetCore.Mvc;
using SAPex.Models;
using SAPex.Controllers;

namespace SAPex
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController: AbstractNameController<SkillViewModel>
    {
    }
}
