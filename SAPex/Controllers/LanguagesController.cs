using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAPex.Models;
using SAPex.Controllers;

namespace SAPex
{
    [Route("api/languages")]
    [ApiController]
    public class LanguagesController : AbstractNameController<LanguageViewModel>
    {
        protected override bool IsValidPostData(LanguageViewModel requestData)
        {
            return requestData.name != null;
        }
        protected override bool IsValidPutData(LanguageViewModel requestData)
        {
            return requestData.name != null;
        }
        protected override void UpdateFields(LanguageViewModel responce, LanguageViewModel requestData)
        {
            responce.name = requestData.name != null ? requestData.name : responce.name;
        }
    }
}
