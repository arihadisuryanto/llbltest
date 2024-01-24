using llbltest.Dtos;
using llbltest.EntityClasses;
using llbltest.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace llbltest.Services
{
    public class DealerService : IDealerService
    {
        private readonly IDealerRepository _dealerRepository;
        private readonly IAzureBlobStorageRepository _azureBlobStorageRepository;
        private readonly IAttachmentRepository _attachmentRepository;
        public DealerService(IDealerRepository dealerRepository, IAzureBlobStorageRepository azureBlobStorageRepository, IAttachmentRepository attachmentRepository)
        {
            _dealerRepository = dealerRepository;
            _azureBlobStorageRepository = azureBlobStorageRepository;
            _attachmentRepository = attachmentRepository;
        }

        public async Task<List<Dealer>> GetDealersAsync()
        {
            return await _dealerRepository.GetDealersAsync();
        }

        public async Task<int> AddDealerAsync(Dealer dealer, IFormFile file)
        {
            byte[] fileBytes;
            dealer.Owner = null;

            var result = await _dealerRepository.AddDealerAsync(dealer);
            if (result is not 0 && file != null)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }

                //add attachment to blob
                if (fileBytes != null)
                {
                    Attachment attachment = new Attachment
                    {
                        EntityId = result,
                        EntityType = EntityType.DEALER,
                        FileName = file.FileName,
                        MimeType = file.ContentType
                    };
                    var resultUpload = await _azureBlobStorageRepository.Upload(attachment, fileBytes);

                    if (resultUpload is not null)
                    {
                        attachment.CloudUrl = resultUpload;
                        await _attachmentRepository.AddAttachmentAsync(attachment);
                    }
                }
            }
            return result;
        }

        public async Task<int> PutDealerAsync(Dealer dealer, int id)
        {
            var existingEntity = await _dealerRepository.GetDealerByIdAsync(id);

            if (existingEntity is not null)
            {
                existingEntity.DealerName = dealer.DealerName;
                existingEntity.OwnerId = dealer.OwnerId;
            }
            return await _dealerRepository.PutDealerAsync(existingEntity);
        }

        public async Task<int> DeleteDealerAsync(int id)
        {
            return await _dealerRepository.DeleteDealerAsync(id);
        }

        public async Task<(MemoryStream, string)> DownloadAttachmentDealerAsync(int id)
        {
            var existingEntity = await _dealerRepository.GetDealerByIdAsync(id);

            if (existingEntity is not null)
            {
                var attachment = await _attachmentRepository.GetAttachmentByEntityIdAndTypeAsync(id, EntityType.DEALER);
                if (attachment is not null)
                {
                    var downloadedByte = await _azureBlobStorageRepository.Download(attachment.FileName);
                    return (downloadedByte, attachment.MimeType);
                }
            }
            return (null, null);
        }
    }
}
