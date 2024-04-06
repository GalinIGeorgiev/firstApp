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

namespace FirstApp.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SurveysController : AdministrationBaseController
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
        public IActionResult Create(CreateSurveyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            return View("AddSurveyOptions", model);
        }

        [HttpGet]
        public IActionResult ManageSurveys(ManageSurveysViewModel model)
        {
            model = SurveyService.ManageSurveys(model);


            return View("ManageSurveys", model);
        }


        [HttpPost]
        public IActionResult SetActiveSurveys(ManageSurveysViewModel model)
        {
            SurveyService.SetActiveSurveys(model);



            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult AddSurveyOptions(CreateSurveyViewModel model)
        {
            //TODO check
            //if (???)
            //{
            //    return this.View(model);

            //}

            SurveyService.Create(model);

            return RedirectToAction("ManageSurveys");

        }
    }
}
