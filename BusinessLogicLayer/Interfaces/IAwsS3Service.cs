using Amazon.S3.Model;
using BusinessLogicLayer.DtoModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAPexAuthService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAwsS3Service
    {
        Task<GetObjectResponse> GetAwsFileAsync(AwsSettingsModel _awsconfig, FileDtoModel fileDtoModel);
        Task<bool> AddFileToAwsAsync(AwsSettingsModel _awsconfig, IFormFile file, string fileName);
        Task<bool> DeleteFileFromAwsAsync(AwsSettingsModel _awsconfig, string fileName);

    }
}
