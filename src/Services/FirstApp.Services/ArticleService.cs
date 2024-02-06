using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Xsl;
using AutoMapper;
using FirstApp.Data;
using FirstApp.Data.Common;
using FirstApp.Data.Models;
using FirstApp.Services.Contracts;
using FirstApp.Services.Mapping;
using FirstApp.Services.ViewModels.Articles;
using FirstApp.Services.ViewModels.Home;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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



        public int Create(CreateArticleViewModel model)
        {          
            var article = Mapper.Map<Article>(model);
            this.db.Articles.Add(article);
            this.db.SaveChanges();

            return article.Id;
        }

        public DetailsArticleViewModel DetailsArticle(int Id)
        {
            var article = db.Articles.Where(x => x.Id == Id).Include(x => x.Team).Include(x => x.Category)
                .Include(x => x.Images).Include(x => x.Videos).Include(x=>x.Comments).ThenInclude(x=>x.FirstAppUser).FirstOrDefault();

            var model = Mapper.Map<DetailsArticleViewModel>(article);

            // TODO no articles without img
            if (model.ImageUrl == null)
            {
                model.ImageUrl= "\\Images\\defaultPic.png";
            }
            return model;
        }

        public Article GiveArticleById(int id)
        {
            var article = db.Articles.Where(x => x.Id == id).Include(x=>x.Team).FirstOrDefault();

            return article;
        }

        public IEnumerable<ArticleViewModel> GiveRandomArticles()
        {
            var articles = db.Articles.Include(x=>x.TeamId).Include(x => x.Team).Include(x => x.Category).Skip(Math.Max(0, db.Articles.Count() - GlobalConstants.NUMBER_OF_ARTICLES_INDEX));
            var articleViewModels = articles.To<ArticleViewModel>().ToList();

            return articleViewModels;
        }

        public void AddImageUrls(int id, IEnumerable<string> imageUrls)
        {
            var product = this.db.Articles.Include(x => x.Images)
                .FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return;
            }

            foreach (var imageUrl in imageUrls)
            {
                var image = new Image { ImageUrl = imageUrl };
                product.Images.Add(image);
            }

            this.db.SaveChanges();
        }

        public void AddVideoUrls(int id, IEnumerable<string> videoUrls)
        {
            var article = this.db.Articles.Include(x => x.Videos)
                .FirstOrDefault(x => x.Id == id);

            if (article == null)
            {
                return;
            }

            foreach (var videoUrl in videoUrls)
            {
                var video = new Video { VideoUrl = videoUrl };
                article.Videos.Add(video);
            }

            this.db.SaveChanges();
        }
    }
}
