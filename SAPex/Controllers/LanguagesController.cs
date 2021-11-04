using Microsoft.AspNetCore.Mvc;
using SAPex.Controllers;
using SAPex.Models;

namespace SAPex
{
    [Route("api/languages")]
    [ApiController]
    public class LanguagesController : AbstractNameController<LanguageViewModel>
    {
    }
}
