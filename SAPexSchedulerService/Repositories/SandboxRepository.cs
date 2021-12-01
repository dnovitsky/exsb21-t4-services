using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SAPexSchedulerService.Data;
using SAPexSchedulerService.Data.EntityModels;

namespace SAPexSchedulerService.Repositories
{
    public class SandboxRepository : ISandboxRepository
    {
        private IDbConnection db;

        public SandboxRepository(AppDbContext dapper)
        {
            this.db = dapper.Db;
        }

        public List<SandboxEntityModel> FindAll()
        {
            var sql = "SELECT *FROM Sandboxes;";
            return db.Query<SandboxEntityModel>(sql).ToList();
        }

        public SandboxEntityModel Update(SandboxEntityModel model)
        {
            string query = "UPDATE Sandboxes SET Status=@Status WHERE Id = @Id";
            db.Execute(query, new { @Status = model.Status, @Id = model.Id });
            return model;   
        }
    }
}
