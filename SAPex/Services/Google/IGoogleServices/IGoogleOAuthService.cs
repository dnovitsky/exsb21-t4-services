﻿using SAPex.Models;

namespace SAPex.Services.Google.IGoogleSevices
{
    public interface IGoogleOAuthService
    {
        public string GetRedirectUrl(string email);
        public GoogleUserAccessToken Add(string email,string code);
        public GoogleUserAccessToken Update(string email);
        public GoogleUserAccessToken GetGoogleUserAccessToken(string email);
        public bool Delete(string email);
    }
}
