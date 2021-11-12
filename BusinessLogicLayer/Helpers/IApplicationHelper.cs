using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Service;
using DbMigrations.Data;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Helpers
{
    public  interface IApplicationHelper
    {
        
        public abstract void CreateTestData();
        public abstract void ClearTestData();
    }
}
