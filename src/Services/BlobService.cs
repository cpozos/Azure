using Azure.Models;
using Azure.Services.Interfaces;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

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

        public async Task<BlobInfoModel> GetBlobAsync(string name)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("pdfs");
            var blobClient = containerClient.GetBlobClient(name);

            try
            {
                var response = await blobClient.DownloadContentAsync();
                return new BlobInfoModel(response.Value.Content, response.Value.Details.ContentType);
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

        public async Task<bool> UploadFileBlobAsync(string filePath, string fileName, bool bOverride = true)
        {
            bool result = false;
            var containerClient = _blobServiceClient.GetBlobContainerClient("pdfs");
            Response<BlobContentInfo> response;
            try
            {
                using FileStream uploadFileStream = File.OpenRead(filePath);
                if (bOverride)
                {
                    var blobClient = containerClient.GetBlobClient(fileName);
                    response = await blobClient.UploadAsync(uploadFileStream, overwrite: true);
                }
                else
                {
                    response = await containerClient.UploadBlobAsync(fileName, uploadFileStream);
                }
            }
            catch (RequestFailedException rfe)
            {
                var s = rfe.Status;
                return result;
            }
            catch(Exception ex)
            {
                var s = ex.InnerException;
                return result;
            }

            result = true;
            return result;
        }
    }
}