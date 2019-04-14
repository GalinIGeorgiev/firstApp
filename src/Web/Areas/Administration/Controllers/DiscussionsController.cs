using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Services;
using FirstApp.Services.Contracts;
using FirstApp.Services.ViewModels.Discussion;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Web.Areas.Administration.Controllers
{
    public class DiscussionsController : AdministrationBaseController
    {
        private IDiscussionService DiscussionService;

        public DiscussionsController(IDiscussionService discussionService)
        {
            DiscussionService = discussionService;
        }
        public IActionResult Index(IndexDiscussionsViewModel model)
        {
             model = DiscussionService.AllDiscussions();

            return View(model);
        }

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDiscussionViewModel model)
        {
            DiscussionService.CreateDiscussion(model);

            return View(nameof(Index));
        }
    }
}