using System;

namespace BusinessLogicLayer.DtoModels.Authorization
{
    public class TokenCredentials
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
