using System;
using SAPex.Models;
using SAPex.Repositories.Google.BaseRepositories;

namespace SAPex.Repositories.Google.IGoogleRepositories
{
    public interface IGoogleUserAccessTokenRepository : GoogleBaseRepository<GoogleUserAccessToken,int>
    {
        public GoogleUserAccessToken FindByEmail(string email);
    }
}
