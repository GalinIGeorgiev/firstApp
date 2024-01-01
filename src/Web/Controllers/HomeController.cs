using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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

        public HomeController(IArticleService articleService, ISurveyService surveyService)
        {
            this.ArticleService = articleService;
            this.SurveyService = surveyService;
        }
        public IActionResult Index(IndexArticleViewModel viewModel)
        {
             viewModel.Articles = ArticleService.GiveRandomArticles().ToList();
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
