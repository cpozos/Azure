using AutoFixture;
using Azure.Services;
using Azure.Storage.Blobs;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests
{
    public class BlobServiceTest
    {
        private readonly BlobService _sut;

        public BlobServiceTest(IFixture fixture)
        {
            var blobServiceClient = fixture.Create<BlobServiceClient>();
            _sut = new BlobService(blobServiceClient);
        }


        [Fact]
        public async Task GetBlob_ShouldReturnNull_WhenNothingFound()
        {
            _sut.UploadFileBlobAsync("", "");
        }
    }
}
