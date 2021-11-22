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
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicLayer.Services
{
    public class SandboxLanguageService : ISandboxLanguageService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly SandboxLanguagesProfile profile = new();

        public SandboxLanguageService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> AddSandboxLanguageAsync(SandboxLanguageDtoModel sandboxLanguageDto)
        {
            try
            {
                SandboxLanguageEntityModel sandboxLanguageEM = profile.mapToEM(sandboxLanguageDto);
                await unitOfWork.SandboxLanguages.CreateAsync(sandboxLanguageEM);
                await unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddSandboxLanguagesListByIdsAsync(Guid sandboxId, IEnumerable<Guid> languageIds)
        {
            try
            { 
                foreach (var id in languageIds)
                {
                    SandboxLanguageDtoModel item = new SandboxLanguageDtoModel { SandboxId = sandboxId, LanguageId = id };
                    await AddSandboxLanguageAsync(item);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateSandboxLanguagesListByIdsAsync(Guid sandboxId, IEnumerable<Guid> languageIds)
        {
            try
            {

                IEnumerable<SandboxLanguageEntityModel> listToDelete = await unitOfWork.SandboxLanguages.FindByConditionAsync(x => x.SandboxId == sandboxId);

                unitOfWork.SandboxLanguages.DeleteRange(listToDelete);

                await AddSandboxLanguagesListByIdsAsync(sandboxId, languageIds);
                await unitOfWork.SaveAsync();
               
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
