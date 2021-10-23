using System;
using SAPex.Models;
using SAPex.Repository.Google.BaseRepository;

namespace SAPex.Repository.Google.IGoogleRepository
{
    public interface IGoogleUserAccessTokenRepository : GoogleBaseRepository<GoogleUserAccessToken,int>
    {
    }
}
