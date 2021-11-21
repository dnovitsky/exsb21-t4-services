using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Options;
using SAPex.Models;
using SAPexAuthService.Models;

namespace SAPex.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        private readonly string _rootFilesPath = Directory.GetCurrentDirectory() + "/files/";
        private readonly IFileService _fileService;
        private readonly AwsSettingsModel _awsconfig;
        private readonly RegionEndpoint _regconfig = RegionEndpoint.EUNorth1;

        public FilesController(IFileService service, IOptions<AwsSettingsModel> awsconfig)
        {
            _fileService = service;
            _awsconfig = awsconfig.Value;
            if (!Directory.Exists(_rootFilesPath))
            {
                Directory.CreateDirectory(_rootFilesPath);
            }
        }

        [HttpGet]
        public async Task<IEnumerable<FileDtoModel>> GetFileListAsync()
        {
            return await _fileService.GetAllFilesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> DownloadFileAsync([FromRoute] Guid id)
        {
            try
            {
                FileDtoModel fileDtoModel = await _fileService.FindFileByIdAsync(id);
                var credentials = new BasicAWSCredentials(_awsconfig.AwsAccessKey, _awsconfig.AwsSecretKey);
                var config = new AmazonS3Config();
                config.RegionEndpoint = _regconfig;
                using var client = new AmazonS3Client(credentials, config);
                var fileTransferUtility = new TransferUtility(client);
                var objectResponse = await fileTransferUtility.S3Client.GetObjectAsync(new GetObjectRequest()
                {
                    BucketName = _awsconfig.AwsBucketName,
                    Key = fileDtoModel.FileName,
                });

                if (objectResponse.ResponseStream == null)
                {
                    return NotFound();
                }

                return File(objectResponse.ResponseStream, objectResponse.Headers.ContentType, fileDtoModel.FileName);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null
                    && (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") || amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Check the provided AWS Credentials.");
                }
                else
                {
                    throw new Exception("Error occurred: " + amazonS3Exception.Message);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadFileAsync(/* [FromHeader] String documentType, TODO review with FE */ [FromForm] IFormFile file)
        {
            try
            {
                var credentials = new BasicAWSCredentials(_awsconfig.AwsAccessKey, _awsconfig.AwsSecretKey);
                var config = new AmazonS3Config();
                config.RegionEndpoint = _regconfig;
                using var client = new AmazonS3Client(credentials, config);
                await using var newMemoryStream = new MemoryStream();
                await file.CopyToAsync(newMemoryStream);
                var fileName = $"{Path.GetFileNameWithoutExtension(file.FileName)}{"_"}{DateTime.Now.ToFileTimeUtc()}{Path.GetExtension(file.FileName)}";
                var uploadRequest = new TransferUtilityUploadRequest
                {
                    InputStream = newMemoryStream,
                    Key = fileName,
                    BucketName = _awsconfig.AwsBucketName,
                    CannedACL = S3CannedACL.PublicRead,
                };
                var fileTransferUtility = new TransferUtility(client);
                await fileTransferUtility.UploadAsync(uploadRequest);
                FileDtoModel fileDtoModel = new ();
                fileDtoModel.Id = new Guid();
                fileDtoModel.FileName = fileName;
                fileDtoModel.CreateDate = DateTime.UtcNow;
                await _fileService.AddFileAsync(fileDtoModel);
                return await Task.FromResult(Ok());
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null
                    && (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") || amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Check the provided AWS Credentials.");
                }
                else
                {
                    throw new Exception("Error occurred: " + amazonS3Exception.Message);
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFileAsync([FromRoute] Guid id)
        {
            try
            {
                FileDtoModel fileDtoModel = await _fileService.FindFileByIdAsync(id);
                _fileService.DeleteFileById(id);

                var credentials = new BasicAWSCredentials(_awsconfig.AwsAccessKey, _awsconfig.AwsSecretKey);
                var config = new AmazonS3Config();
                config.RegionEndpoint = _regconfig;
                using var client = new AmazonS3Client(credentials, config);
                var fileTransferUtility = new TransferUtility(client);
                await fileTransferUtility.S3Client.DeleteObjectAsync(new DeleteObjectRequest()
                {
                    BucketName = _awsconfig.AwsBucketName,
                    Key = fileDtoModel.FileName,
                });
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null
                    && (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") || amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Check the provided AWS Credentials.");
                }
                else
                {
                    throw new Exception("Error occurred: " + amazonS3Exception.Message);
                }
            }

            return await Task.FromResult(Ok());
        }
    }
}