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
    public class FunctionalRolesController : AbstractNameController<FunctionalRoleViewModel>
    {
        protected override bool IsValidPostData(FunctionalRoleViewModel requestData)
        {
            return requestData.name != null && requestData.access != null;
        }
        protected override bool IsValidPutData(FunctionalRoleViewModel requestData)
        {
            return requestData.name != null;
        }
        protected override void UpdateFields(FunctionalRoleViewModel responce, FunctionalRoleViewModel requestData)
        {
            responce.name = requestData.name != null ? requestData.name : responce.name;
            responce.access = requestData.access != null ? requestData.access : responce.access;
        }
    }
}
