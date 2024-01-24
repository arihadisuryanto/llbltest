using llbltest.EntityClasses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace llbltest.Services
{
    public interface IDealerService
    {
        Task<List<Dealer>> GetDealersAsync();
        Task<int> AddDealerAsync(Dealer dealer, IFormFile attachment);
        Task<int> PutDealerAsync(Dealer dealer, int id);
        Task<int> DeleteDealerAsync(int id);
        Task<(MemoryStream, string)> DownloadAttachmentDealerAsync(int id);
    }
}
