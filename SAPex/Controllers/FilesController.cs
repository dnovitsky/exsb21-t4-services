using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

        public FilesController()
        {
            if (!Directory.Exists(_rootFilesPath))
            {
                Directory.CreateDirectory(_rootFilesPath);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> DownloadFile([FromRoute] int id)
        {
            string existingFile = Directory.EnumerateFiles(_rootFilesPath, id.ToString() + ".*").FirstOrDefault();
            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(existingFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(existingFile);
            return File(bytes, contentType, Path.GetFileName(existingFile));
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(/* [FromHeader] String documentType, TODO review with FE */ [FromForm] IFormFile file)
        {
            string filepath = _rootFilesPath + file.FileName;

            Stream stream = file.OpenReadStream();
            using (FileStream outputFileStream = new FileStream(filepath, FileMode.Create))
            {
                DirectoryInfo info = new DirectoryInfo(file.ContentDisposition);
                stream.CopyTo(outputFileStream);
                return await Task.FromResult(Ok());
            }
        }
    }
}