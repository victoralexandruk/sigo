using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.Normas.Data
{
    public class NormaStorage
    {
        private readonly BlobContainerClient _blobContainerClient;

        public NormaStorage(IConfiguration config)
        {
            var blobServiceClient = new BlobServiceClient(config.GetConnectionString("BlobStorage"));
            _blobContainerClient = blobServiceClient.GetBlobContainerClient("normas");
        }

        public async Task UploadFileAsync(string fileName, Stream fileStream)
        {
            var blobClient = _blobContainerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(fileStream, true).ConfigureAwait(false);
        }

        public async Task DownloadFileAsync(string fileName, Stream fileStream)
        {
            var blobClient = _blobContainerClient.GetBlobClient(fileName);
            await blobClient.DownloadToAsync(fileStream).ConfigureAwait(false);
        }

        public async Task DeleteFileAsync(string fileName)
        {
            var blobClient = _blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteIfExistsAsync().ConfigureAwait(false);
        }
    }
}
