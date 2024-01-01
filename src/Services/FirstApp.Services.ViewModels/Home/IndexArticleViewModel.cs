﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Data.Models;
using FirstApp.Services.ViewModels.Survey;

namespace FirstApp.Services.ViewModels.Home
{
    public class IndexArticleViewModel
    {
        private IEnumerable<ArticleViewModel> articles;

        public IEnumerable<ArticleViewModel> Articles { get; set; }

        private IEnumerable<ActiveSurveysViewModel> activeSurveys;

        public  ICollection<ActiveSurveysViewModel> ActiveSurveys { get; set; }



    }
}
