using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Data.Models;
using FirstApp.Services.ViewModels.Survey;
using FirstApp.Services.ViewModels.Video;

namespace FirstApp.Services.ViewModels.Home
{
    public class IndexArticleViewModel
    {
        private IEnumerable<ArticleViewModel> articles;

        public IEnumerable<ArticleViewModel> Articles { get; set; }

        private IEnumerable<ArticleViewModel> favoriteArticles;

        public IEnumerable<ArticleViewModel> FavoriteArticles { get; set; }

        private IEnumerable<ActiveSurveysViewModel> activeSurveys;

        public  ICollection<ActiveSurveysViewModel> ActiveSurveys { get; set; }

        private IEnumerable<VideoViewModel> videos;

        public  ICollection<VideoViewModel> Videos { get; set; }



    }
}
