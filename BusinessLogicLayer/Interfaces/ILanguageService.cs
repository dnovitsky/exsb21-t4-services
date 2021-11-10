using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Interfaces
{
    public interface ILanguageService :IDisposable
    {
        Task<bool> AddLanguageAsync(LanguageDtoModel languageDto);
        Task<IEnumerable<LanguageDtoModel>> GetAllLanguagesAsync();
        Task<IEnumerable<LanguageDtoModel>> FindLanguagesAsync(Expression<Func<LanguageEntityModel, bool>> expression);
        void UpdateLanguage(LanguageDtoModel languageDto);
        Task<LanguageDtoModel> FindLanguageByIdAsync(Guid id);
        void DeleteLanguage(Guid id);
    }
}
