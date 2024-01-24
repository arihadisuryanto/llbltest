using llbltest.EntityClasses;
using System.IO;
using System.Threading.Tasks;

namespace llbltest.Repositories
{
    public interface IAzureBlobStorageRepository
    {
        Task<string> Upload(Attachment entity, byte[] file);
        Task<MemoryStream> Download(string fileName);
    }
}
