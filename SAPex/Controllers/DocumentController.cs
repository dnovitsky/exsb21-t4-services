using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SAPex.Controllers
{
    [ApiController]
    [Route("api/document")]
    public class DocumentsController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> UploadDocument(
            [FromHeader] String documentType,
            [FromForm] IFormFile file
            )
        {
            Stream stream = file.OpenReadStream();         
            using (FileStream outputFileStream = new FileStream(@"C:\ExadelSandbox\exsb21-t4-services\SAPex\uploads\" + file.FileName, FileMode.Create))
            {
                DirectoryInfo info = new DirectoryInfo(file.ContentDisposition);
                stream.CopyTo(outputFileStream);
                return await Task.FromResult(Ok());
            }
        }
    }
}
