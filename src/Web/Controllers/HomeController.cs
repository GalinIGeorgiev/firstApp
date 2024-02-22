using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FirstApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using FirstApp.Web.Models;
using FirstApp.Services;
using FirstApp.Services.Contracts;
using FirstApp.Services.ViewModels.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace FirstApp.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IArticleService ArticleService;
        public ISurveyService SurveyService;
        private UserManager<FirstAppUser> UserManager;

        public HomeController(IArticleService articleService, ISurveyService surveyService, UserManager<FirstAppUser> userManager)
        {
            this.ArticleService = articleService;
            this.SurveyService = surveyService;
            this.UserManager = userManager;
        }
        public IActionResult Index(IndexArticleViewModel viewModel)
        {
            var user =  UserManager.GetUserAsync(User).Result;

            viewModel.Articles = ArticleService.GiveRandomArticles().ToList();

            if (  user!=null && user.FavoriteTeam != null)
            {
                viewModel.FavoriteArticles = ArticleService.GiveFavoriteArticles(user.FavoriteTeam).ToList();
            }

           
            viewModel.ActiveSurveys = SurveyService.GiveActiveSurveys();
             
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
