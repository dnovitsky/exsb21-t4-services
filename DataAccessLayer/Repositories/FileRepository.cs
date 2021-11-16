using DbMigrations.EntityModels;
using DbMigrations.Data;
using DataAccessLayer.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class FileRepository : Repository<FileEntityModel>, IFileRepository
    {
        public FileRepository(AppDbContext context)
           : base(context)
        { }
    }
}
