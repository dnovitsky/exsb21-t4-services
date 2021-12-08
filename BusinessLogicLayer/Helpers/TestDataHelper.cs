using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DbMigrations.Data;
using DbMigrations.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Helpers
{
    public class TestDataHelper
    {
        public static void InitTestData(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            using (AppDbContext db = new AppDbContext(options))
            {
                if (!db.AppSettings.Any())
                {
                    db.AppSettings.Add(new AppSettingEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "TestTaskUrl",
                        Value = "http://64.227.114.210:9090/api/testtasks/"
                    });
                    db.AppSettings.Add(new AppSettingEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "TestResultUrl",
                        Value = "http://localhost:5001/upload-files/"
                    });
                    db.AppSettings.Add(new AppSettingEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "TestTaskLifeTime",
                        Value = "48"
                    });
                    db.AppSettings.Add(new AppSettingEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "TestTasksSapexEmail",
                        Value = "testtasks@sapex.com"
                    });
                    db.SaveChanges();
                }
            }
        }
    }
}
