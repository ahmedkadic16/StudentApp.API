using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace StudentApp.API.Repositories
{
    public interface IImageRepository
    {
        Task<string> Upload(IFormFile file, string fileName);
    }
}
