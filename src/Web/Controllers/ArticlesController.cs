using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Services.Contracts;
using FirstApp.Services.ViewModels.Articles;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Web.Controllers
{
    public class ArticlesController : BaseController
    {
        private IArticleService ArticleService;

        public ArticlesController(IArticleService articleService)
        {
            ArticleService = articleService;
        }

       

        public IActionResult DetailsArticle(int id)
        {
            var model= ArticleService.DetailsArticle(id);
            return View(model);
        }
    }
}