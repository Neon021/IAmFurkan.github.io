using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace My3rdBlog.Data.FileManager
{
    public interface IFileManager
    {
        FileStream ImageStream(string image);
        Task<string> SaveImage(IFormFile image);
        bool RemoveImage(string image);
    }
}
