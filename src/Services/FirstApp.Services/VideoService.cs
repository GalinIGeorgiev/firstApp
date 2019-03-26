using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FirstApp.Data.Common;
using FirstApp.Services.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FirstApp.Services
{
    public class VideoService : IVideoService
    {
        private IHostingEnvironment hostingEnvironment;

        public VideoService(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public async void UploadVideo(IFormFile formImage, string path)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await formImage.CopyToAsync(stream);
            }
        }

        public async Task<IEnumerable<string>> UploadVideos(IList<IFormFile> formVideos, int count, string template, int id)
        {
            var videosUrls = new List<string>();

            for (int i = 0; i < formVideos.Count; i++)
            {
                var urlName = $"Id{id}_{count + i}";

                var path = hostingEnvironment.WebRootPath + GlobalConstants.ARTICLE_VIDEO_PATH_TEMPLATE;
                var videoPath = string.Format(path, urlName);


                using (var stream = new FileStream(videoPath, FileMode.Create))
                {
                    await formVideos[i].CopyToAsync(stream);
                }

                var imageRoot = videoPath.Replace(hostingEnvironment.WebRootPath, "");
                videosUrls.Add(imageRoot);
            }

            return videosUrls;
        }
    }
}