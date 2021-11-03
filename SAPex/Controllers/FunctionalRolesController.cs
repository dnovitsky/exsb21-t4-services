using Microsoft.AspNetCore.Mvc;
using SAPex.Models;
using SAPex.Controllers;

namespace SAPex
{
    [Route("api/functionalroles")]
    [ApiController]
    public class FunctionalRolesController : AbstractNameController<FunctionalRoleViewModel>
    {
    }
}
