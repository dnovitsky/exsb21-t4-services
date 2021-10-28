using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SAPex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadFile(
            //[FromHeader] String documentType, TODO review with FE
            [FromForm] IFormFile file
            )
        {
            Stream stream = file.OpenReadStream();
            string filepath = @"files\";
            using (FileStream outputFileStream = new FileStream(filepath + file.FileName, FileMode.Create))
            {
                DirectoryInfo info = new DirectoryInfo(file.ContentDisposition);
                stream.CopyTo(outputFileStream);
                return await Task.FromResult(Ok());
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> DownloadFile(int id)
        {
            var filePath = @"files\";
            string existingFile = Directory.EnumerateFiles(filePath, id.ToString() + ".*").FirstOrDefault();
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(existingFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = await System.IO.File.ReadAllBytesAsync(existingFile);
            return File(bytes, contentType, Path.GetFileName(existingFile));
        }
    }
}

