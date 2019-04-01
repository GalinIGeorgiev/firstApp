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
    public class CommentsController : BaseController
    {
        private ICommentService CommentService;
        private UserManager<FirstAppUser> UserManager;

        public CommentsController(ICommentService commentService, UserManager<FirstAppUser> userManager)
        {
            this.CommentService = commentService;
            this.UserManager = userManager;
        }



        public IActionResult AddCommentToArticle(DetailsArticleViewModel model)
        {
            var commentText = model.CurrentCommentContent;
            var articleId = model.Id;

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);    
            FirstAppUser user = UserManager.FindByIdAsync(userId).Result;

            CommentService.AddCommentToArticle(user,commentText, articleId);

            return RedirectToAction("DetailsArticle", "Articles","2");
        }
    }
}