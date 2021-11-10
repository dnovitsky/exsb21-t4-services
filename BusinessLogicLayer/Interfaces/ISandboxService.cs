using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Interfaces
{
    public interface ISandboxService : IDisposable
    {
        Task<bool> AddSandboxAsync(SandboxDtoModel sandboxDto);
        Task<IEnumerable<SandboxDtoModel>> GetAllSandboxesAsync();
        Task<IEnumerable<SandboxDtoModel>> FindSandBoxesAsync(Expression<Func<SandboxEntityModel, bool>> expression);
        void UpdateSandbox(SandboxDtoModel sandboxDto);
        Task<SandboxDtoModel> FindSandboxByIdAsync(Guid id);
<<<<<<< HEAD
        void DeleteSandbox(int id);
=======
        void DeleteSandbox(Guid id);
>>>>>>> dev
    }
}
