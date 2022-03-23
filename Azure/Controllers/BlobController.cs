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
            var file = File(blob.Data.ToStream(), blob.ContentType);
            file.FileDownloadName = "Renamed.pdf";
            return file;
        }

        [HttpPost]
        public async Task UploadBlob()
        {
            await _blobService.UploadFileBlobAsync("", "");
        }
    }
}
