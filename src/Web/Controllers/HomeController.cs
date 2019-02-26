using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstApp.Web.Models;
using FirstApp.Services;
using FirstApp.Services.Contracts;
using FirstApp.Services.ViewModels.Home;

namespace FirstApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IArticleService ArticleService;

        public HomeController(IArticleService articleService)
        {
            this.ArticleService = articleService;
        }
        public IActionResult Index(IndexArticleViewModel viewModel)
        {
             viewModel.Articles = ArticleService.GiveRandomArticles().Take(10).ToList();
               
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
