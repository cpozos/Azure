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

        [HttpGet]
        public async Task<IActionResult> GetBlob([FromQuery] GetBlobRequest request)
        {
            var blob = await _blobService.GetBlobAsync("");
            return Ok(blob);
        }

        [HttpPost]
        public async Task UploadBlob()
        {
            await _blobService.UploadFileBlobAsync("", "");
        }
    }
}
