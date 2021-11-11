using DbMigrations.EntityModels;
using DbMigrations.Data;
using DataAccessLayer.IRepositories;


namespace DataAccessLayer.Repositories
{
    public class UserRepository : Repository<UserEntityModel>, IUserRepository
    {
        public UserRepository(AppDbContext context)
            : base(context)
        { }

    }
}
