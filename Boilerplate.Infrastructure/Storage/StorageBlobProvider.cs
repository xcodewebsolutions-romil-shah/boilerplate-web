using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Boilerplate.Infrastructure.Contracts;
using System.IO;
using System.Threading.Tasks;

namespace Boilerplate.Infrastructure.Storage
{
    public class StorageBlobProvider : IStorageBlobProvider
    {
        private readonly BlobContainerClient _blobContainer;

        public StorageBlobProvider(string storageConnString, string containerKey)
        {
            _blobContainer = new BlobContainerClient(storageConnString, containerKey);
        }

        public BlobContainerClient GetBlobContainer()
        {
            return _blobContainer;
        }

        public async Task<BlobDownloadResult> DownloadAsync(string fileName)
        {
            BlobClient blob = _blobContainer.GetBlobClient(fileName);
            return await blob.DownloadContentAsync();
        }

        public async Task DeleteAsync(string fileName)
        {
            await _blobContainer.CreateIfNotExistsAsync();

            BlobClient blob = _blobContainer.GetBlobClient(fileName);
            await blob.DeleteIfExistsAsync();
        }

        public async Task UploadAsync(string fileName, Stream stream)
        {
            await _blobContainer.CreateIfNotExistsAsync();

            BlobClient blob = _blobContainer.GetBlobClient(fileName);
            await blob.UploadAsync(stream);
        }
    }
}
