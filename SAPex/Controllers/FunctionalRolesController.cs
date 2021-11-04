using Microsoft.AspNetCore.Mvc;
using SAPex.Controllers;
using SAPex.Models;

namespace SAPex
{
    [Route("api/functionalroles")]
    [ApiController]
    public class FunctionalRolesController : AbstractNameController<FunctionalRoleViewModel>
    {
    }
}
