using BusinessLogicLayer.DtoModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ILanguageLevelService
    {
        Task<IEnumerable<LanguageLevelDtoModel>> GetAllLanguageLevelsAsync();
    }
}
