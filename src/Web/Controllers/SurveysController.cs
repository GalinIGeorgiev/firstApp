using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Services;
using Microsoft.AspNetCore.Mvc;
using FirstApp.Services.ViewModels.Articles;
using FirstApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using FirstApp.Services.ViewModels.Home;
using FirstApp.Data.Common;
using FirstApp.Services.ViewModels.Survey;
using FirstApp.Web.Controllers;

namespace FirstApp.Web.Controllers
{
    
    public class SurveysController : BaseController
    {

        private ISurveyService SurveyService;



        public SurveysController(ISurveyService surveyService)
        {
            SurveyService = surveyService;           
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddVote(string name)
        {
            SurveyService.AddVote(1);
            Console.WriteLine("333GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG");
            Console.WriteLine(name);

            return View("_Survey");
        }
    }
}
