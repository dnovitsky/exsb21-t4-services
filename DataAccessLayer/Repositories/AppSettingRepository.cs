using DataAccessLayer.IRepositories;
using DbMigrations.Data;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class AppSettingRepository : Repository<AppSettingEntityModel>, IAppSettingRepository
    {
        public AppSettingRepository(AppDbContext context)
            : base(context)
        { }
    }
}
