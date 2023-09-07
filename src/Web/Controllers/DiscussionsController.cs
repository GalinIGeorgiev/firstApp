using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Data.Models;
using FirstApp.Services;
using FirstApp.Services.Contracts;
using FirstApp.Services.ViewModels.Discussion;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Web.Controllers
{
    public class DiscussionsController : BaseController
    {
        private IDiscussionService DiscussionService;
        private ICommentService CommentService;
        private UserManager<FirstAppUser> UserManager;

        public DiscussionsController(IDiscussionService discussionService, ICommentService commentService, UserManager<FirstAppUser> userManager)
        {
            DiscussionService = discussionService;
            CommentService = commentService;
            UserManager = userManager;
        }
        public  IActionResult Index(List<DiscussionViewModel> model)
        {
            model = DiscussionService.AllDiscussions().ToList();

            return View(model);
        }

        // TODO delete
        //public IActionResult Create()
        //{           
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(DiscussionViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return this.View(model);
        //    }


        //    DiscussionService.CreateDiscussion(model);

        //    return RedirectToAction(nameof(Index));   
        //}

        public IActionResult Details(int id)
        {
            DiscussionViewModel discussionViewModel = DiscussionService.DetailsDiscussion(id);

            return View(discussionViewModel);
        }

        public IActionResult AddComment(DiscussionViewModel model)
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result;
            var discussionId = model.Id;

            var commentText = model.CurrentCommentContent;

            CommentService.AddCommentToDiscussion(user, commentText, discussionId);

            return RedirectToAction(nameof(Details), new { id = discussionId });
        }
    }
}