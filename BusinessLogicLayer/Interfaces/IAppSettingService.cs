using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAppSettingService
    {
        Task<Guid> AddAppSettingAsync(AppSettingDtoModel AppSettingeDto);

        Task<AppSettingDtoModel> FindAppSettingByIdAsync(Guid id);
        Task<IEnumerable<AppSettingDtoModel>> FindAppSettingAsync(Expression<Func<AppSettingEntityModel, bool>> expression);

        Task<IEnumerable<AppSettingDtoModel>> GetAllAppSettingAsync();

        void UpdateAppSetting(AppSettingDtoModel AppSettingDto);

        void Delete(Guid id);
    }
}
