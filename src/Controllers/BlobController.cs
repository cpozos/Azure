using Azure.Contracts;
using Azure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Azure.Controllers
{
    public class BlobController : ControllerBase
    {
        private readonly IBlobService _blobService;

        public BlobController(IBlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpGet("{blobName}")]
        public async Task<IActionResult> GetBlob(string blobName)
        {
            var blob = await _blobService.GetBlobAsync($"{blobName}.pdf");

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = "Name.pdf",
                Inline = false //Browser downloads it - False: Browser opens it
            };

            Response.Headers.Add("Content-Disposition", cd.ToString());
            Response.Headers.Add("X-Content-Type-Options", "nosniff");

            var file = File(blob.Data.ToStream(), blob.ContentType);
            file.FileDownloadName = "Renamed.pdf";
            return file;
        }

        [HttpGet("save")]
        public async Task<IActionResult> UploadBlob()
        {
            await _blobService.UploadFileBlobAsync("C:\\test.pdf", "test2.pdf", false);
            return Ok();
        }
    }
}
