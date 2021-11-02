using Microsoft.AspNetCore.Mvc;
using SAPex.Models;
using SAPex.Controllers;

namespace SAPex
{
    [Route("api/languages")]
    [ApiController]
    public class LanguagesController : AbstractNameController<LanguageViewModel>
    {
    }
}
