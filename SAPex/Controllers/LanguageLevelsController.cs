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
    }
}
