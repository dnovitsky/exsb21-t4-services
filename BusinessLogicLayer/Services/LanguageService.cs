using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Mapping;
using BusinessLogicLayer.Interfaces;
using System.Linq.Expressions;
using AutoMapper;
using DataAccessLayer.Service;

namespace BusinessLogicLayer.Services
{
    public class LanguageService : ILanguageService
    {
        protected readonly LanguageProfile profile;
        private readonly IUnitOfWork unitOfWork;

        public LanguageService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> AddLanguageAsync(LanguageDtoModel languageDto)
        {
            try
            {
                LanguageEntityModel languageEM = profile.mapToEM(languageDto);
                await Task.Run(() => unitOfWork.Languages.CreateAsync(languageEM));
                unitOfWork.SaveAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public void DeleteLanguage(int id)
        {
            unitOfWork.Languages.Delete(id);
        }

        public async Task<LanguageDtoModel> FindLanguageByIdAsync(int id)
        {
            LanguageEntityModel languageEM = await unitOfWork.Languages.FindByIdAsync(id);
            LanguageDtoModel languageDto = profile.mapToDto(languageEM);
            return languageDto;
        }

        public async Task<IEnumerable<LanguageDtoModel>> FindLanguagesAsync(Expression<Func<LanguageEntityModel, bool>> expression)
        {
            IEnumerable<LanguageEntityModel> languagesEM = await unitOfWork.Languages.FindByConditionAsync(expression);
            return profile.mapListToDto(languagesEM);
        }

        public async Task<IEnumerable<LanguageDtoModel>> GetAllLanguagesAsync()
        {
            IEnumerable<LanguageEntityModel> languagesEM = await Task.Run(() => unitOfWork.Languages.GetAllAsync());
            return profile.mapListToDto(languagesEM);
        }

        public void UpdateLanguage(LanguageDtoModel languageDto)
        {            
            LanguageEntityModel languageEM = profile.mapToEM(languageDto);
            unitOfWork.Languages.Update(languageEM);
            unitOfWork.SaveAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
