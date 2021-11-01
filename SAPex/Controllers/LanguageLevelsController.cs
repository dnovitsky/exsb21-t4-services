using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAPex.Models;
using SAPex.Controllers;

namespace SAPex
{
    [Route("api/languagelevels")]
    [ApiController]
    public class LanguageLevelsController : AbstractNameController<LanguageLevelViewModel>
    {
        protected override bool IsValidPostData(LanguageLevelViewModel requestData)
        {
            return requestData.name != null;
        }
        protected override bool IsValidPutData(LanguageLevelViewModel requestData)
        {
            return requestData.name != null;
        }
        protected override void UpdateFields(LanguageLevelViewModel responce, LanguageLevelViewModel requestData)
        {
            responce.name = requestData.name != null ? requestData.name : responce.name;
        }
    }
}
