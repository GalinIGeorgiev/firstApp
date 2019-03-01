using FirstApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Services.ViewModels.Home;

namespace FirstApp.Services.Contracts
{
    public interface IArticleService
    {
        IEnumerable<ArticleViewModel> GiveRandomArticles();
    }
}
