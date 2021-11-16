using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IFileRepository
    {
        Task<IEnumerable<FileEntityModel>> GetAllAsync();
        Task<IEnumerable<FileEntityModel>> FindByConditionAsync(Expression<Func<FileEntityModel, bool>> expression);
        Task<FileEntityModel> FindByIdAsync(Guid id);

        Task<FileEntityModel> CreateAsync(FileEntityModel item);

        void Update(FileEntityModel item);
        void Delete(Guid id);
    }
}
