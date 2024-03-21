using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirstApp.Services.ViewModels.Video;

namespace FirstApp.Services.Contracts
{
    public interface IVideoService
    {
        Task<IEnumerable<string>> UploadVideos(IList<IFormFile> formVideos, int count, string template, int id);

        int AddVideo(CreateVideoViewModel model);

        ICollection<VideoViewModel> GiveNewVideos();
    }
}