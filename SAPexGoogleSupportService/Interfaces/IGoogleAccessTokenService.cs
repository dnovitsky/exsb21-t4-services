using System;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using SAPexGoogleSupportService.Models;

namespace SAPexGoogleSupportService.Interfaces
{
    public interface IGoogleAccessTokenService
    {
        public string GetRedirectUrl(string state);
        public Task<GoogleResponse<GoogleAccessTokenEntityModel>> FindByUserIdAsync(Guid userId);
        public Task<GoogleResponse<GoogleAccessTokenEntityModel>> CreateAsync(string code, string state);
        public Task<GoogleAccessTokenEntityModel> FindByIdAsync(Guid id);
        public Task<GoogleAccessTokenEntityModel> CreateAsync(GoogleAccessTokenEntityModel item);
        public Task<GoogleAccessTokenEntityModel> UpdateAsync(GoogleAccessTokenEntityModel item);
        public GoogleAccessTokenEntityModel Delete(Guid id);
    }
}
