using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FirstApp.Data.Models;
using FirstApp.Services.Contracts;
using FirstApp.Services.ViewModels.Articles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Web.Controllers
{
    public class DiscussionsController : BaseController
    {
        private readonly IDiscussionService DiscussionService;

        public DiscussionsController(IDiscussionService discussionService)
        {
            DiscussionService = discussionService;
        }


        public IActionResult Index()
        {
            var model = DiscussionService.AllDiscussions();

            return View(model);
        }

    }
}