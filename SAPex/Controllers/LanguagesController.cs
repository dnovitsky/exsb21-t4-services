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
        public LanguagesController()
        {
            this.storageList = new List<LanguageViewModel>() {
                new LanguageViewModel(Guid.NewGuid(), "Lang 1"),
                new LanguageViewModel(Guid.NewGuid(), "Lang 2"),
                new LanguageViewModel(Guid.NewGuid(), "Lang 3"),
                new LanguageViewModel(Guid.NewGuid(), "Lang 4")
            };
        }
    }
}
