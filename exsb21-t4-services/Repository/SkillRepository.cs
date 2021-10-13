using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using exsb21_t4_services.Data;
using exsb21_t4_services.Models;

namespace exsb21_t4_services.Repository.IRepository
{
    public class SkillRepository: ISkillRepository
    {
        private IDbConnection db;

        public SkillRepository(DapperDbContext dapper)
        {
            this.db = dapper.Db;
        }

        public Skill Add(Skill skill)
        {
            var sql = "INSERT INTO Skills(SkillName) VALUES(@SkillName); SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = db.Query<int>(sql, new { @SkillName = skill.SkillName }).Single();
            skill.SkillId = id;
            return skill;
        }

        public List<Skill> FindAll()
        {
            var sql = "SELECT *FROM Skills;";
            return db.Query<Skill>(sql).ToList();
        }

        public Skill FindById(int id)
        {
            var sql = "SELECT *FROM Skills WHERE SkillId=@SkillId;";
            return db.Query<Skill>(sql, new { @SkillId = id }).Single();
        }

    }
} 
