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
    public interface IStackTechnologyService : IDisposable
    {
        Task<bool> AddStackTechnologyAsync(StackTechnologyDtoModel stackTechnologyDto);
        Task<IEnumerable<StackTechnologyDtoModel>> GetAllStackTechnologiesAsync();
        Task<IEnumerable<StackTechnologyDtoModel>> FindStackTechnologiesAsync(Expression<Func<StackTechnologyEntityModel, bool>> expression);
        void UpdateStackTechnology(StackTechnologyDtoModel sandboxDto);
        Task<StackTechnologyDtoModel> FindStackTechnologyByIdAsync(Guid id);
        void DeleteStackTechnology(Guid id);
    }
}
