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
        public FunctionalRolesController()
        {
            this.storageList = new List<FunctionalRoleViewModel>() {
                new FunctionalRoleViewModel(Guid.NewGuid(), "FuncRole 1", "R"),
                new FunctionalRoleViewModel(Guid.NewGuid(), "FuncRole 2", "RW"),
                new FunctionalRoleViewModel(Guid.NewGuid(), "FuncRole 3", "RWC"),
                new FunctionalRoleViewModel(Guid.NewGuid(), "FuncRole 4", "RXWC")
            };
        }
    }
}
