using llbltest.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace llbltest.Repositories
{
    public interface IDealerRepository
    {
        Task<List<Dealer>> GetDealersAsync();
        Task<Dealer> GetDealerByIdAsync(int id);
        Task<int> AddDealerAsync(Dealer dealer);
        Task<int> PutDealerAsync(Dealer dealer);
        Task<int> DeleteDealerAsync(int id);
    }
}
