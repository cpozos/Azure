using Azure.Models;
using Azure.Services.Interfaces;
using Azure.Storage.Blobs;

namespace Azure.Services
{
    public class BlobService : IBlobService
    {
        private readonly string _containerName = "pdfs";
        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<BlobInfo> GetBlobAsync(string name)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(name);
            var response = await blobClient.DownloadContentAsync();
            return new BlobInfo(response.Value.Content, response.Value.Details.ContentType);
        }

        public Task UploadFileBlobAsync(string filePath, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}