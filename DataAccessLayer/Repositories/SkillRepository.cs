using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.IRepositories;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using DbMigrations.Data;

namespace DataAccessLayer.Repositories
{
    public class SkillRepository : Repository<SkillEntityModel>, ISkillRepository
    {
        public SkillRepository(AppDbContext context)
            : base(context)
        { }
    }
}
