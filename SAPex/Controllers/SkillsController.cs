using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAPex.Models;
using SAPex.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace SAPex
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController: AbstractNameController<SkillViewModel>
    {
        protected override bool IsValidPostData(SkillViewModel requestData)
        {
            return requestData.name != null;
        }
        protected override bool IsValidPutData(SkillViewModel requestData)
        {
            return requestData.name != null;
        }
        protected override void UpdateFields(SkillViewModel responce, SkillViewModel requestData)
        {
            responce.name = requestData.name != null ? requestData.name : responce.name;
        }
    }
}
