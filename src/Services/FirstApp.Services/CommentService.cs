using System.Linq;
using FirstApp.Data;
using FirstApp.Data.Models;
using FirstApp.Services.Contracts;
using FirstApp.Services.ViewModels.Articles;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Services
{
    public class CommentService : ICommentService
    {
        private readonly FirstAppContext Db;
        private readonly IArticleService ArticleService;

        public CommentService(FirstAppContext db, IArticleService articleService)
        {
            this.Db = db;
            this.ArticleService = articleService;
        }
        public int AddCommentToArticle(FirstAppUser user, string commentText, int articleId)
        {
            var comment = new Comment();

            comment.FirstAppUser = user;
            comment.Content = commentText;
            comment.ArticleId = articleId;
            var article = ArticleService.GiveArticleById(articleId);

            Db.Comments.Add(comment);
            article.Comments.Add(comment);

            Db.SaveChanges();
            return articleId;
        }
    }
}