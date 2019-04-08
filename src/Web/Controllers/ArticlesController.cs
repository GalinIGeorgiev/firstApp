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
    public class ArticlesController : BaseController
    {
        private IArticleService ArticleService;
        private ICommentService CommentService;
        private UserManager<FirstAppUser> UserManager;

        public ArticlesController(IArticleService articleService, ICommentService commentService, UserManager<FirstAppUser> userManager)
        {
            ArticleService = articleService;
            CommentService = commentService;
            this.UserManager = userManager;
        }

        public IActionResult AddComment(DetailsArticleViewModel model)
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result;
            var articleId = model.Id;
         
            var commentText = model.CurrentCommentContent;

            
            CommentService.AddCommentToArticle(user, commentText, articleId);

            return RedirectToAction(nameof(DetailsArticle), new {  id=articleId });
        }


        public IActionResult DetailsArticle(int id)
        {
            var model = ArticleService.DetailsArticle(id);

            return View(model);
        }
    }
}