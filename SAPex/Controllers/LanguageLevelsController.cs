using Microsoft.AspNetCore.Mvc;
using SAPex.Models;
using SAPex.Controllers;

namespace SAPex
{
    [Route("api/languagelevels")]
    [ApiController]
    public class LanguageLevelsController : AbstractNameController<LanguageLevelViewModel>
    {
    }
}
