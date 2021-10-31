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
    public class LanguagesController : AbstractController<LanguageViewModel>
    {
        protected override Predicate<LanguageViewModel> FindByRequestDataCallback(LanguageViewModel requestData)
        {
            return (item) => { return item.name == requestData.name; };
        }
    }
}
