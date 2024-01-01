using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Services;
using FirstApp.Services.Contracts;
using FirstApp.Services.ViewModels.Discussion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal;

namespace FirstApp.Web.Areas.Administration.Controllers
{
    public class DiscussionsController : AdministrationBaseController
    {
        private IDiscussionService DiscussionService;

        public DiscussionsController(IDiscussionService discussionService)
        {
            DiscussionService = discussionService;
        }


        public IActionResult Index(List<DiscussionViewModel> model)
        {
            model = DiscussionService.AllDiscussions().ToList();

            return View(model);
        }

        public IActionResult Create()
        {           
            return View();
        }


        [HttpPost]
        public IActionResult Create(DiscussionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            DiscussionService.CreateDiscussion(model);

            return RedirectToAction(nameof(Index));   
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            if (!DiscussionService.DeleteDiscussion(id))
            {
                return this.View();
            }

            var model = DiscussionService.AllDiscussions().ToList();

            return View(nameof(Index), model);

        }
    }
}