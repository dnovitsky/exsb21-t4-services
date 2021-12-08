using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace SAPex.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        private readonly string _rootFilesPath = Directory.GetCurrentDirectory() + "/files/";
        private readonly IFileService _fileService;
        private readonly IAwsS3Service _awsS3Service;
        private readonly AwsSettingsModel _awsconfig;
        private readonly FileValidationSettingsModel _fileValidationConfig;
        private readonly RegionEndpoint _regconfig = RegionEndpoint.EUNorth1;

        public FilesController(IFileService service, IAwsS3Service awss3service, IOptions<AwsSettingsModel> awsconfig, IOptions<FileValidationSettingsModel> fileValidationConfig)
        {
            _awsS3Service = awss3service;
            _fileService = service;
            _awsconfig = awsconfig.Value;
            _fileValidationConfig = fileValidationConfig.Value;
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
        public async Task<IActionResult> DownloadFileAsync([FromRoute] Guid id)
        {
            try
            {
                FileDtoModel fileDtoModel = await _fileService.FindFileByIdAsync(id);

                var objectResponse = await _awsS3Service.GetAwsFileAsync(_awsconfig, fileDtoModel);
                if (objectResponse.ResponseStream == null)
                {
                    return await Task.FromResult(NotFound());
                }

                return File(objectResponse.ResponseStream, objectResponse.Headers.ContentType, fileDtoModel.FileName);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null
                    && (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") || amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    return await Task.FromResult(Forbid());
                }
                else
                {
                    return await Task.FromResult(BadRequest());
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest());
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadFileAsync(/* [FromHeader] String documentType, TODO review with FE */ [FromForm] IFormFile file)
        {
            var fileString = Path.GetFileNameWithoutExtension(file.FileName);
            var fileDate = DateTime.Now.ToFileTimeUtc();
            var fileExt = Path.GetExtension(file.FileName);
            var fileName = $"{fileString}{"_"}{fileDate}{fileExt}";
            var fileExtValidation = _fileValidationConfig.FileExtension.Split(" ");
            var fileMaxSize = _fileValidationConfig.MaxFileSize * 1024 * 1024;

            if (fileExtValidation.Any(fileExt.Contains) && file.Length < fileMaxSize)
            {
                bool awsRes = await _awsS3Service.AddFileToAwsAsync(_awsconfig, file, fileName);

                FileDtoModel fileDtoModel = new ();
                fileDtoModel.Id = Guid.NewGuid();
                fileDtoModel.FileName = fileName;
                fileDtoModel.CreateDate = DateTime.UtcNow;

                bool fileDbRes = await _fileService.AddFileAsync(fileDtoModel);
                if (fileDbRes && awsRes)
                {
                    return await Task.FromResult(Ok(fileDtoModel.Id));
                }
                else
                {
                    return await Task.FromResult(BadRequest());
                }
            }
            else
            {
                return await Task.FromResult(ValidationProblem());
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateFileCategory(Guid id, int fileCategory)
        {
            FileDtoModel fileDtoModel = await _fileService.FindFileByIdAsync(id);
            if (fileDtoModel == null)
            {
                return await Task.FromResult(NotFound());
            }

            bool check = await _fileService.UpdateFileCategory(id, fileCategory);
            return await Task.FromResult(Ok(check));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFileAsync([FromRoute] Guid id)
        {
            try
            {
                FileDtoModel fileDtoModel = await _fileService.FindFileByIdAsync(id);
                _fileService.DeleteFileById(id);

                bool awsres = await _awsS3Service.DeleteFileFromAwsAsync(_awsconfig, fileDtoModel.FileName);

                if (awsres)
                {
                    return await Task.FromResult(Ok());
                }
                else
                {
                    return await Task.FromResult(BadRequest());
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest());
            }
        }
    }
}