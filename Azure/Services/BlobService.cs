using Azure.Services.Interfaces;
using Azure.Storage.Blobs.Models;

namespace Azure.Services
{
    public class BlobService : IBlobService
    {
        public Task<BlobInfo> GetBlobAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task UploadFileBlobAsync(string filePath, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}