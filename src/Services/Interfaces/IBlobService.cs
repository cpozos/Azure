using Azure.Models;

namespace Azure.Services.Interfaces
{
    public interface IBlobService
    {
        public Task<BlobInfoModel> GetBlobAsync(string name);

        public Task<bool> UploadFileBlobAsync(string filePath, string fileName, bool bOverride = false);
    }
}