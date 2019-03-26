using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstApp.Services.Contracts
{
    public interface IVideoService
    {
        Task<IEnumerable<string>> UploadVideos(IList<IFormFile> formVideos, int count, string template, int id);
    }
}