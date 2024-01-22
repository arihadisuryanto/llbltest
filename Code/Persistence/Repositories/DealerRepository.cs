using llbltest.EntityClasses;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace llbltest.Repositories
{
    public class DealerRepository : IDealerRepository
    {
        private LlbltestDataContext _dbContext;
        public DealerRepository(LlbltestDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Dealer>> GetDealersAsync()
        {
            return await _dbContext.Dealers.Include(x => x.Owner).Include(x => x.Salesmen).ToListAsync();
        }

        public async Task<Dealer> GetDealerByIdAsync(int id)
        {
            return await _dbContext.Dealers.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> AddDealerAsync(Dealer dealer)
        {
            if (_dbContext != null)
            {
                await _dbContext.Dealers.AddAsync(dealer);
                await _dbContext.SaveChangesAsync();

                return dealer.Id;
            }

            return 0;
        }

        public async Task<int> PutDealerAsync(Dealer dealer)
        {
            int result = 0;
            if (_dbContext != null)
            {
                _dbContext.Dealers.Update(dealer);

                result = await _dbContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<int> DeleteDealerAsync(int id)
        {
            int result = 0;

            if (_dbContext != null)
            {
                //Find the post for specific post id
                var dealer = await _dbContext.Dealers.FirstOrDefaultAsync(x => x.Id == id);

                if (dealer != null)
                {
                    //Delete that post
                    _dbContext.Dealers.Remove(dealer);

                    //Commit the transaction
                    result = await _dbContext.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }
    }
}
