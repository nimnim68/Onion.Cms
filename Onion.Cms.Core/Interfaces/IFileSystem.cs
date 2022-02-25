using System.Threading.Tasks;

namespace Onion.Cms.ApplicationServices.Interfaces
{
    public interface IFileSystem
    {
        Task<bool> SavePicture(string pictureName, string pictureBase64);
    }
}