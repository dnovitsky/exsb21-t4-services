using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface IAppSettingRepository
    {
        Task<IEnumerable<AppSettingEntityModel>> GetAllAsync();
        Task<IEnumerable<AppSettingEntityModel>> FindByConditionAsync(Expression<Func<AppSettingEntityModel, bool>> expression);
        Task<AppSettingEntityModel> FindByIdAsync(Guid id);

        Task<AppSettingEntityModel> CreateAsync(AppSettingEntityModel item);

        void Update(AppSettingEntityModel item);
        void Delete(Guid id);
    }
}
