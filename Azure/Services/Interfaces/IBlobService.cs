using Azure.Models;

namespace Azure.Services.Interfaces
{
    public interface IBlobService
    {
        public Task<BlobInfo> GetBlobAsync(string name);

        public Task UploadFileBlobAsync(string filePath, string fileName);
    }
}