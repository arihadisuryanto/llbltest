using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using llbltest.EntityClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace llbltest.Repositories
{
    public class AzureBlobStorageRepository : IAzureBlobStorageRepository
    {
        private readonly BlobContainerClient _blobContainerClient;
        private readonly IConfiguration _configuration;
        public AzureBlobStorageRepository(IConfiguration configuration) 
        { 
            _configuration = configuration;
            _blobContainerClient = new BlobContainerClient(_configuration.GetConnectionString("AzureBlobStorageConnection"), _configuration.GetValue<string>("AzureBlobStorageContainerName"));
        }

        public async Task<string> Upload(Attachment entity, byte[] file)
        {
            //Blob
            var fullName = Regex.Replace(entity.FileName, @"[^\u0000-\u007F]+", "a").Replace(" ", "");
            var segments = fullName.Split("/");
            var folderPath = segments.Length > 1 ? $"{string.Join("/", segments.SkipLast(1))}/" : "";
            var fileName = $"{segments.Last()}";
            BlobClient blobClient = _blobContainerClient.GetBlobClient($"{folderPath}{fileName}");

            //Upload
            using var stream = new MemoryStream(file)
            {
                Position = 0
            };

            var response = await blobClient.UploadAsync(stream);

            return GetBlobUri(blobClient);
        }

        public async Task<MemoryStream> Download(string fileName)
        {
            MemoryStream readStream = new MemoryStream();
            BlobClient blobClientRead = _blobContainerClient.GetBlobClient(fileName);
            await blobClientRead.DownloadToAsync(readStream);
            return readStream;
        }

        private string GetBlobUri(BlobClient blobClient)
        {

            if (!string.IsNullOrEmpty(blobClient.Uri.Query))
            {
                return blobClient.Uri.AbsoluteUri.Replace(blobClient.Uri.Query, string.Empty);
            }

            return blobClient.Uri.AbsoluteUri;
        }


    }
}
