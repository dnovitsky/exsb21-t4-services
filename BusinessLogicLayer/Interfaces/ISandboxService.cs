using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Interfaces
{
    public interface ISandboxService : IDisposable
    {
        Task<bool> AddSandboxAsync(SandboxDtoModel sandboxDto);
        Task<IEnumerable<SandboxDtoModel>> GetAllSandboxesAsync();
        Task<PagedList<SandboxDtoModel>> GetPagedSandboxesAsync(InputParametrsDtoModel parametrs);
        Task<IEnumerable<SandboxDtoModel>> FindSandBoxesAsync(Expression<Func<SandboxEntityModel, bool>> expression);
        void UpdateSandbox(SandboxDtoModel sandboxDto);
        Task<SandboxDtoModel> FindSandboxByIdAsync(Guid id);
        void DeleteSandbox(Guid id);
    }
}
