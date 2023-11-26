using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Services;
using Microsoft.AspNetCore.Mvc;
using FirstApp.Services.ViewModels.Articles;
using FirstApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using FirstApp.Services.ViewModels.Home;
using FirstApp.Data.Common;

namespace FirstApp.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ArticlesController : AdministrationBaseController
    {
        private ICategoryService CategoryService;
        private ITeamService TeamService;
        private IArticleService ArticleService;
        private IImageService ImageService;
        private IVideoService VideoService;



        public ArticlesController(ICategoryService categoryService, ITeamService teamService, IArticleService articleService, IImageService imageService, IVideoService videoService)
        {
            CategoryService = categoryService;
            TeamService = teamService;
            ArticleService = articleService;
            ImageService = imageService;
            VideoService = videoService;
        }



        [HttpGet]
        public IActionResult Create()
        {
            this.ViewData["Categories"] = this.CategoryService.GetAllCategories()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                });

            this.ViewData["Teams"] = this.TeamService.GetAllTeams()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            int newArticleId = ArticleService.Create(model);

            //images
            if (model.Images != null)
            {
                int existingImages = 0;

                var imageUrls = await this.ImageService.UploadImages(model.Images.ToList(), existingImages,
                    GlobalConstants.ARTICLE_IMAGE_PATH_TEMPLATE, newArticleId);

                this.ArticleService.AddImageUrls(newArticleId, imageUrls);
            }
            //videos
            if (model.Videos != null)
            {
                int existingVideos = 0;

                var videoUrls = await this.VideoService.UploadVideos(model.Videos.ToList(), existingVideos,
                    GlobalConstants.ARTICLE_VIDEO_PATH_TEMPLATE, newArticleId);

                this.ArticleService.AddVideoUrls(newArticleId, videoUrls);
            }

            return View();
        }
    }
}
