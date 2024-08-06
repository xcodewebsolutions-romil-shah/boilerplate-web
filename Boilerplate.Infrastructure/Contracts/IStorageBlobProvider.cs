using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Infrastructure.Contracts
{
    public interface IStorageBlobProvider
    {
        BlobContainerClient GetBlobContainer();

        Task<BlobDownloadResult> DownloadAsync(string fileName);

        Task DeleteAsync(string fileName);

        Task UploadAsync(string fileName, Stream stream);
    }
}
