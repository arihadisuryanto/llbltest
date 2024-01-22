using llbltest.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace llbltest.Services
{
    public interface IDealerService
    {
        Task<List<Dealer>> GetDealersAsync();
        Task<int> AddDealerAsync(Dealer dealer);
        Task<int> PutDealerAsync(Dealer dealer, int id);
        Task<int> DeleteDealerAsync(int id);
    }
}
