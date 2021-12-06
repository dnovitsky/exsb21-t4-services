using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class AppSettingService : IAppSettingService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AppSettingProfile profile = new AppSettingProfile();

        public AppSettingService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Guid> AddAppSettingAsync(AppSettingDtoModel AppSettingeDto)
        {
            AppSettingEntityModel AppSettingEM = profile.mapToEM(AppSettingeDto);
            AppSettingEntityModel newAppSetting = await unitOfWork.AppSettings.CreateAsync(AppSettingEM);
            await unitOfWork.SaveAsync();
            return newAppSetting.Id;
        }

        public void Delete(Guid id)
        {
            unitOfWork.AppSettings.Delete(id);
            unitOfWork.Save();
        }

        public async Task<AppSettingDtoModel> FindAppSettingByIdAsync(Guid id)
        {
            AppSettingEntityModel AppSettingEM = await unitOfWork.AppSettings.FindByIdAsync(id);
            AppSettingDtoModel AppSettingDto = profile.mapToDto(AppSettingEM);
            return AppSettingDto;
        }

        public async Task<IEnumerable<AppSettingDtoModel>> FindAppSettingAsync(Expression<Func<AppSettingEntityModel, bool>> expression)
        {
            IEnumerable<AppSettingEntityModel> AppSettingEM = await unitOfWork.AppSettings.FindByConditionAsync(expression);
            return profile.mapListToDto(AppSettingEM);
        }

        public async Task<IEnumerable<AppSettingDtoModel>> GetAllAppSettingAsync()
        {
            IEnumerable<AppSettingEntityModel> AppSettingsEM = await unitOfWork.AppSettings.GetAllAsync();
            return profile.mapListToDto(AppSettingsEM);
        }

        public void UpdateAppSetting(AppSettingDtoModel AppSettingDto)
        {
            AppSettingEntityModel AppSettingEM = profile.mapToEM(AppSettingDto);
            unitOfWork.AppSettings.Update(AppSettingEM);
            unitOfWork.Save();
        }

    }
}
