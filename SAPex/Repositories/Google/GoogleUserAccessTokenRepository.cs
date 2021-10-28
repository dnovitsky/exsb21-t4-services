using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SAPex.Data;
using SAPex.Models;
using SAPex.Repositories.Google.IGoogleRepositories;

namespace SAPex.Repository.Google
{
    public class GoogleUserAccessTokenRepository: IGoogleUserAccessTokenRepository
    {

        private IDbConnection db;

        public GoogleUserAccessTokenRepository(DapperDbContext dapper)
        {
            this.db = dapper.Db;
        }
        public List<GoogleUserAccessToken> FindAll()
        {
            var sql = "SELECT *FROM GoogleUserAccessTokens;";
            return db.Query<GoogleUserAccessToken>(sql).ToList();
        }
        public GoogleUserAccessToken FindById(int id)
        {
            var sql = "SELECT *FROM GoogleUserAccessTokens WHERE Id=@Id;";
            return db.Query<GoogleUserAccessToken>(sql, new { @Id = id }).SingleOrDefault();
        }
        public GoogleUserAccessToken FindByEmail(string email)
        {
            var sql = "SELECT *FROM GoogleUserAccessTokens WHERE Email=@Email;";
            return db.Query<GoogleUserAccessToken>(sql, new { @Email = email }).SingleOrDefault();
        }
        public GoogleUserAccessToken Add(GoogleUserAccessToken item)
        {
            var sql = "INSERT INTO GoogleUserAccessTokens(Expires_in,Created_in,Email,Access_token,Refresh_token,Scope,Token_type) VALUES(@Expires_in,@Created_in,@Email,@Access_token,@Refresh_token,@Scope,@Token_type); SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = db.Query<int>(sql, new
            {
                @Expires_in=item.Expires_in,
                @Created_in = item.Created_in,
                @Email = item.Email,
                @Access_token = item.Access_token,
                @Refresh_token = item.Refresh_token,
                @Scope=item.Scope,
                @Token_type = item.Token_type
            }).Single();
            item.Id = id;
            return item;
        }
        public GoogleUserAccessToken Update(GoogleUserAccessToken item)
        {
            string query = "UPDATE GoogleUserAccessTokens SET " +
                "Expires_in =@Expires_in, " +
                "Created_in=@Created_in, " +
                "Email=@Email, " +
                "Access_token=@Access_token, " +
                "Refresh_token=@Refresh_token, " +
                "Scope=@Scope, " +
                "Token_type=@Token_type " +
                "WHERE Id = @Id";
            db.Execute(query, new
            {
                @Expires_in = item.Expires_in,
                @Created_in = item.Created_in,
                @Email = item.Email,
                @Access_token = item.Access_token,
                @Refresh_token = item.Refresh_token,
                @Scope = item.Scope,
                @Token_type = item.Token_type,
                @Id=item.Id
            });
            return item;
        }
        public bool Delete(GoogleUserAccessToken item)
        {
            var sqlStatement = "DELETE FROM GoogleUserAccessTokens WHERE Id = @Id";
            db.Execute(sqlStatement, new { Id = item.Id });
            return true;
        }  
    }
}
