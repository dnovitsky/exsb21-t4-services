using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace SAPex.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        private readonly string _rootFilesPath = Directory.GetCurrentDirectory() + "/files/";
        private readonly IFileService _fileService;

        public FilesController(IFileService service)
        {
            _fileService = service;
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
            var provider = new FileExtensionContentTypeProvider();

            FileDtoModel fileDtoModel = await _fileService.FindFileByIdAsync(id);
            if (fileDtoModel == null)
            {
                return await Task.FromResult(NotFound());
            }

            string existingFile = Directory.EnumerateFiles(_rootFilesPath, fileDtoModel.FileName).FirstOrDefault();
            if (!provider.TryGetContentType(existingFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(existingFile);
            return File(bytes, contentType, Path.GetFileName(existingFile));
        }

        [HttpPost]
        public async Task<IActionResult> UploadFileAsync(/* [FromHeader] String documentType, TODO review with FE */ [FromForm] IFormFile file)
        {
            string filepath = _rootFilesPath + file.FileName;
            FileDtoModel fileDtoModel = new ();
            fileDtoModel.Id = new Guid();
            fileDtoModel.FileName = file.FileName;
            fileDtoModel.AwsS3Id = 1; // don't have this yet
            fileDtoModel.CreateDate = DateTime.UtcNow;
            Stream stream = file.OpenReadStream();
            await _fileService.AddFileAsync(fileDtoModel);
            using (FileStream outputFileStream = new FileStream(filepath, FileMode.Create))
            {
                DirectoryInfo info = new DirectoryInfo(file.ContentDisposition);
                stream.CopyTo(outputFileStream);
                return await Task.FromResult(Ok());
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFileAsync([FromRoute] Guid id)
        {
            FileDtoModel fileDtoModel = await _fileService.FindFileByIdAsync(id);
            string filepath = _rootFilesPath + fileDtoModel.FileName;
            FileInfo file = new FileInfo(filepath);
            if (file.Exists)
            {
                file.Delete();
                _fileService.DeleteFileById(id);
                return await Task.FromResult(Ok());
            }
            else
            {
                return await Task.FromResult(BadRequest());
            }
        }
    }
}