using FirstApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Services.ViewModels.Articles;
using FirstApp.Services.ViewModels.Home;

namespace FirstApp.Services.Contracts
{
    public interface IArticleService
    {
        IEnumerable<ArticleViewModel> GiveRandomArticles();
        int Create(CreateArticleViewModel model);

        DetailsArticleViewModel DetailsArticle(int Id);

        void AddImageUrls(int id, IEnumerable<string> imageUrls);

        void AddVideoUrls(int id, IEnumerable<string> videoUrls);
    }
}
