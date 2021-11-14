using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;

namespace BusinessLogicLayer.Interfaces
{
    public interface ISandboxLanguagesService
    {
        Task<bool> AddSandboxLanguageAsync(SandboxLanguageDtoModel sandboxLanguageDto);
    }
}
