using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Data.Models;

namespace FirstApp.Services.ViewModels.Home
{
    public class IndexArticleViewModel
    {
        public IEnumerable<ArticleViewModel> Articles { get; set; }

        
    }
}
