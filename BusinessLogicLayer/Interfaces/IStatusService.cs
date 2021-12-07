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
    public interface IStatusService
    {
        Task<IEnumerable<StatusDtoModel>> GetAllStatusesAsync();
        Task<StatusDtoModel> FindStatusByIdAsync(Guid id);

        Task<StatusDtoModel> FindStatusByConditionAsync(Expression<Func<StatusEntityModel, bool>> expression);
    }
}
