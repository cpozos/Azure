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
            var containerClient = _blobServiceClient.GetBlobContainerClient("pdfs");
            var blobClient = containerClient.GetBlobClient(name);

            try
            {
                var response = await blobClient.DownloadContentAsync();
                return new BlobInfo(response.Value.Content, response.Value.Details.ContentType);
            }
            catch (RequestFailedException ex)
            {
                var msj = "Error";
                if (ex.Status == (int)System.Net.HttpStatusCode.NotFound)
                {
                    if (ex.ErrorCode == "BlobNotFound")
                    {
                        msj = $"{msj}. Blob was not found";
                    }
                    else if (ex.ErrorCode == "ContainerNotFound")
                    {
                        msj = $"{msj}. Blob was not found";
                    }
                }
                throw ex;
            }
        }

        public Task UploadFileBlobAsync(string filePath, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}