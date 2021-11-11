using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class LanguageLevelService : ILanguageLevelService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly LanguageLevelProfile profile = new LanguageLevelProfile();
        public LanguageLevelService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<LanguageLevelDtoModel>> GetAllLanguageLevelsAsync()
        {
            IEnumerable<LanguageLevelEntityModel> languagelevelsEM = await Task.Run(() => unitOfWork.LanguageLevels.GetAllAsync());
            return profile.mapListToDto(languagelevelsEM);
        }
    }
}
