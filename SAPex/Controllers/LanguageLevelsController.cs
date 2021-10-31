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
    public class LanguageLevelsController : AbstractController<LanguageLevelViewModel>
    {
        protected override Predicate<LanguageLevelViewModel> FindByRequestDataCallback(LanguageLevelViewModel requestData)
        {
            return (item) => { return item.name == requestData.name; };
        }
    }
}
