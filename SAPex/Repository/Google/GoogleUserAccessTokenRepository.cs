using System;
using System.Collections.Generic;
using SAPex.Models;
using SAPex.Repository.Google.BaseRepository;
using SAPex.Repository.Google.IGoogleRepository;

namespace SAPex.Repository.Google
{
    public class GoogleUserAccessTokenRepository: IGoogleUserAccessTokenRepository
    {
        public GoogleUserAccessTokenRepository()
        {

        }

        public GoogleUserAccessToken Add(GoogleUserAccessToken item)
        {
            throw new NotImplementedException();
        }

        public List<GoogleUserAccessToken> FindAll()
        {
            throw new NotImplementedException();
        }

        public GoogleUserAccessToken FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
