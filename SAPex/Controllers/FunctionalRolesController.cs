using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using SAPex.Models;
using SAPex.Controllers;

namespace SAPex
{
    [Route("api/functionalroles")]
    [ApiController]
    public class FunctionalRolesController : AbstractController<FunctionalRoleViewModel>
    {
    }
}
