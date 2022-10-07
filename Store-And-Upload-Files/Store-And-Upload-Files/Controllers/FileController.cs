using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Store_And_Upload_Files.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {

        // Temporary in-memory Dictionary to hold the file content
        private static readonly Dictionary<string, FileModel> FileListArray = new Dictionary<string, FileModel>();

        public FileController()
        {

        }


        [HttpPost("UploadFile")]
        public IActionResult UploadFiles(IFormFile file)
        {
            // gets the byts so we can desrilizae when we fetch the content
            var fileBytes = GetFileBytes(file);
            var keyName = $"{ file.FileName }_{Guid.NewGuid()}";

            var fileModel = new FileModel { ContentType = file.ContentType, fileBytes = fileBytes };
            FileListArray.Add(keyName, fileModel);
 
            var result = new
            {
                FileName = keyName,
                ContentType = file.ContentType
            };

            return Ok(result);

        }

        [HttpGet("GetFile")]
        public ActionResult GetFile(string fileName)
        {
            // search the dictionary for the key to retain the value
            var foundFile = FileListArray.FirstOrDefault(kvp => kvp.Key == fileName).Value;

            return File(foundFile.fileBytes, foundFile.ContentType);
        }



        private byte[] GetFileBytes(IFormFile file)
        {
            // open the stream and copy file content into it
            // reutrn array of Bytes
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                return ms.ToArray();

            }
        }

    }
}
