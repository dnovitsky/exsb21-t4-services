using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using SAPexAuthService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class AwsS3Service : IAwsS3Service
    {
        public async Task<GetObjectResponse> GetAwsFileAsync(AwsSettingsModel _awsconfig, FileDtoModel fileDtoModel)
        {
            var credentials = new BasicAWSCredentials(_awsconfig.AwsAccessKey, _awsconfig.AwsSecretKey);

            var config = new AmazonS3Config();
            config.RegionEndpoint = RegionEndpoint.EUNorth1;

            using var client = new AmazonS3Client(credentials, config);

            var fileTransferUtility = new TransferUtility(client);
            var objectResponse = await fileTransferUtility.S3Client.GetObjectAsync(new GetObjectRequest()
            {
                BucketName = _awsconfig.AwsBucketName,
                Key = fileDtoModel.FileName,
            });

            return objectResponse;

        }

        public async Task<bool> AddFileToAwsAsync(AwsSettingsModel _awsconfig, IFormFile file, string fileName)
        {
            try
            {
                var credentials = new BasicAWSCredentials(_awsconfig.AwsAccessKey, _awsconfig.AwsSecretKey);
                var config = new AmazonS3Config();
                config.RegionEndpoint = RegionEndpoint.EUNorth1;

                using var client = new AmazonS3Client(credentials, config);
                await using var newMemoryStream = new MemoryStream();
                await file.CopyToAsync(newMemoryStream);



                var uploadRequest = new TransferUtilityUploadRequest
                {
                    InputStream = newMemoryStream,
                    Key = fileName,
                    BucketName = _awsconfig.AwsBucketName,
                    CannedACL = S3CannedACL.PublicRead,
                };

                var fileTransferUtility = new TransferUtility(client);
                await fileTransferUtility.UploadAsync(uploadRequest);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public async Task<bool> DeleteFileFromAwsAsync(AwsSettingsModel _awsconfig, string fileName)
        {
            try
            {
                var credentials = new BasicAWSCredentials(_awsconfig.AwsAccessKey, _awsconfig.AwsSecretKey);
                var config = new AmazonS3Config();
                config.RegionEndpoint = RegionEndpoint.EUNorth1;

                using var client = new AmazonS3Client(credentials, config);

                var fileTransferUtility = new TransferUtility(client);
                await fileTransferUtility.S3Client.DeleteObjectAsync(new DeleteObjectRequest()
                {
                    BucketName = _awsconfig.AwsBucketName,
                    Key = fileName,
                });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }

}
