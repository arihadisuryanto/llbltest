using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Attachment = llbltest.EntityClasses.Attachment;

namespace llbltest.Repositories
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private LlbltestDataContext _dbContext;
        public AttachmentRepository(LlbltestDataContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public async Task<int> AddAttachmentAsync(Attachment attachment)
        {
            if (_dbContext != null)
            {
                await _dbContext.Attachments.AddAsync(attachment);
                await _dbContext.SaveChangesAsync();

                return attachment.Id;
            }

            return 0;
        }

        public async Task<Attachment> GetAttachmentByEntityIdAndTypeAsync(int id, string entityType)
        {
            return await _dbContext.Attachments.Where(x => x.EntityId == id && x.EntityType == entityType).FirstOrDefaultAsync();
        }
    }
}
