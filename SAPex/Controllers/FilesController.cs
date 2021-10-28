using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
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
            string filepath = @"uploads\";
            using (FileStream outputFileStream = new FileStream(filepath + file.FileName, FileMode.Create))
            {
                DirectoryInfo info = new DirectoryInfo(file.ContentDisposition);
                stream.CopyTo(outputFileStream);
                return await Task.FromResult(Ok());
            }
        }
    }
}

