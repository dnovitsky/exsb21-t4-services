using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using exsb21_t4_services.Data;
using exsb21_t4_services.Models;
using exsb21_t4_services.Repository.IRepository;

namespace exsb21_t4_services.Repository
{
    public class SpecializationRepository : ISpecializationRepository
    {

        private IDbConnection db;

        public SpecializationRepository(DapperDbContext dapper)
        {
            this.db = dapper.Db;
        }


        public Specialization Add(Specialization specialization)
        {
            var sql = "INSERT INTO Specializations(SpecializationName) VALUES(@SpecializationName); SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = db.Query<int>(sql, new { @SpecializationName = specialization.SpecializationName }).Single();
            specialization.SpecializationId = id;
            return specialization;
        }

        public List<Specialization> FindAll()
        {
            var sql = "SELECT *FROM Specializations;";
            return db.Query<Specialization>(sql).ToList();
        }

        public Specialization FindById(int id)
        {
            var sql = "SELECT *FROM Specializations WHERE SpecializationId=@SpecializationId;";
            return db.Query<Specialization>(sql, new { @SpecializationId = id }).Single();
        }
    }
}
