using llbltest.Dtos;
using llbltest.EntityClasses;
using llbltest.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace llbltest.Services
{
    public class DealerService : IDealerService 
    {
        private readonly IDealerRepository _dealerRepository;
        public DealerService(IDealerRepository dealerRepository) 
        { 
            _dealerRepository = dealerRepository;
        }  

        public async Task<List<Dealer>> GetDealersAsync()
        {
            return await _dealerRepository.GetDealersAsync();
        }

        public async Task<int> AddDealerAsync(Dealer dealer)
        {
            return await _dealerRepository.AddDealerAsync(dealer);
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
    }
}
