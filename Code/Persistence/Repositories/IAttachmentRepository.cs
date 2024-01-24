using llbltest.EntityClasses;
using System.Threading.Tasks;

namespace llbltest.Repositories
{
    public interface IAttachmentRepository
    {
        Task<int> AddAttachmentAsync(Attachment attachment);
        Task<Attachment> GetAttachmentByEntityIdAndTypeAsync(int id, string entityType);
    }
}
