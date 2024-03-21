using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using FirstApp.Services.ViewModels.Articles;
using FirstApp.Services.ViewModels.Team;
using FirstApp.Services.ViewModels.Video;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstApp.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VideosController : AdministrationBaseController
    {
        private IVideoService VideoService;
        private ICategoryService CategoryService;
        private ITeamService TeamService;

        public VideosController(IVideoService videoService,
         ICategoryService categoryService,
         ITeamService teamService
        )
        {
            VideoService = videoService;
            CategoryService = categoryService;
            TeamService = teamService;
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
        public IActionResult Create(CreateVideoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            VideoService.AddVideo(model);

           return RedirectToAction("Index", "Home");
        }
    }
}
