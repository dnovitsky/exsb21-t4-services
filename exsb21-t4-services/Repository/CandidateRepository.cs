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
    public class CandidateRepository: ICandidateRepository
    {
        private IDbConnection db;

        public CandidateRepository(DapperDbContext dapper)
        {
            this.db = dapper.Db;
        }

        public Candidate Add(Candidate candidate)
        {
            var sql = "INSERT INTO Candidates(CandidateName, CandidateSurname, SpecialisationId, Location, Education, Email, Skype, Phone, Status ) " +
                      "VALUES(@CandidateName, @CandidateSurname, @SpecialisationId, @Location, @Education, @Email, @Skype, @Phone, @Status); SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = db.Query<int>(sql, new {
                @CandidateName=candidate.CandidateName,
                @CandidateSurname = candidate.CandidateSurname,
                @SpecialisationId = candidate.SpecialisationId,
                @Location = candidate.Location,
                @Education = candidate.Education,
                @Email = candidate.Email,
                @Skype = candidate.Skype,
                @Phone = candidate.Phone,
                @Status = candidate.Status
            }).Single();
            candidate.CandidateId = id;
            return candidate;
        }

        public List<Candidate> FindAll()
        {
            var sql = "SELECT *FROM Candidates;";
            return db.Query<Candidate>(sql).ToList();
        }

        public Candidate FindById(int id)
        {
            var sql = "SELECT *FROM Candidates WHERE SkillId=@SkillId;";
            return db.Query<Candidate>(sql, new { @SkillId = id }).Single();
        }
    }
}
