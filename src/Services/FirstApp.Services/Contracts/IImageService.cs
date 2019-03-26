using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstApp.Services.Contracts
{
    public interface IImageService
    {
        void UploadImage(IFormFile formImage, string path);

        Task<IEnumerable<string>> UploadImages(IList<IFormFile> formImages, int count, string template, int id);      
    }
}