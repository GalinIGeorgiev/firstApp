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
    public class ImageService : IImageService
    {
        private IHostingEnvironment hostingEnvironment;

        public ImageService(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        public async void UploadImage(IFormFile formImage, string path)
        {
            using (var stream=new FileStream(path,FileMode.Create))
            {
                await formImage.CopyToAsync(stream);
            }
        }

        public async Task<IEnumerable<string>> UploadImages(IList<IFormFile> formImages, int count, string template, int id)
        {
            var imageUrls = new List<string>();

            for (int i = 0; i < formImages.Count; i++)
            {
                var urlName = $"Id{id}_{count + i}";

                var path = hostingEnvironment.WebRootPath+"\\Images\\Articles\\Image{0}.jpg";
                var imagePath = string.Format(path, urlName);


                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await formImages[i].CopyToAsync(stream);
                }

                var imageRoot = imagePath.Replace(hostingEnvironment.WebRootPath, "");
                imageUrls.Add(imageRoot);
            }

            return imageUrls;
        }
    }
}