using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Xsl;
using FirstApp.Data;
using FirstApp.Data.Models;
using FirstApp.Services.Contracts;
using FirstApp.Services.ViewModels.Home;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Services
{
    public class ArticleService : IArticleService
    {
        private readonly FirstAppContext db;

        public ArticleService(FirstAppContext db)
        {
            this.db = db;
        }

        public IEnumerable<ArticleViewModel> GiveRandomArticles()
        {
            var articles = db.Articles.Include(x=>x.Category).OrderBy(x => Guid.NewGuid()).Select(x => new ArticleViewModel()
            {
                Content = x.Content.Substring(0, 100)+"...",
                Category = x.Category.Name,
                CreatedOn = x.CreatedOn,
                ImageUrl = x.ImageUrl                
            }).ToList();
            

            
          
            return articles;
        }

        
    }
}
