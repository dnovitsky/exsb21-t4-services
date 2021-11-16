using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;

namespace BusinessLogicLayer.Interfaces
{
    public interface ISandboxLanguageService
    {
        Task<bool> AddSandboxLanguageAsync(SandboxLanguageDtoModel sandboxLanguageDto);
        Task<bool> AddSandboxLanguagesListByIdsAsync(Guid sandboxId, IEnumerable<Guid> languageIds);
    }
}
