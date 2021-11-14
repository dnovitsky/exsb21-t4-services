using Microsoft.AspNetCore.Mvc;
using SAPex.Controllers;
using SAPex.Models;

namespace SAPex
{
    [Route("api/languagesTest")]
    [ApiController]
    public class LanguagesControllerTest : AbstractNameController<LanguageViewModelTest>
    {
    }
}
