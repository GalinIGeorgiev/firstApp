using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AutoMapper;
using FirstApp.Data;
using FirstApp.Data.Common;
using FirstApp.Data.Models;
using FirstApp.Services.Contracts;
using FirstApp.Services.Mapping;
using FirstApp.Services.ViewModels.Video;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FirstApp.Services
{
    public class VideoService : IVideoService
    {
        private IHostingEnvironment hostingEnvironment;
        private readonly FirstAppContext Db;

        public VideoService(FirstAppContext db, IHostingEnvironment hostingEnvironment)
        {
            this.Db = db;
            this.hostingEnvironment = hostingEnvironment;
        }

        public int AddVideo(CreateVideoViewModel model)
        {
            if (model.Videos != null)
            {
                string urlName = (Db.Videos.Last().Id + 100).ToString();
                var path = hostingEnvironment.WebRootPath + GlobalConstants.VIDEO_PATH_TEMPLATE;
                var videoPath = string.Format(path, urlName);


                UploadVideo(model.Videos.FirstOrDefault(), videoPath);

                model.VideoUrl = (videoPath.Replace(hostingEnvironment.WebRootPath, ""));
            }

            var video = Mapper.Map<Video>(model);
            this.Db.Videos.Add(video);
            this.Db.SaveChanges();

            return video.Id;
        }



        public ICollection<VideoViewModel> GiveNewVideos()
        {
            var videos = Db.Videos.OrderByDescending(x => x.Id).Take(5);
            var videoViewModels = videos.To<VideoViewModel>().ToList();

            return videoViewModels;
        }


        public async void UploadVideo(IFormFile formVideo, string path)
        {

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await formVideo.CopyToAsync(stream);
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