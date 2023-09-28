using FirstApp.Data.Models;
using FirstApp.Services.ViewModels.Articles;

namespace FirstApp.Services.Contracts
{
    public interface ICommentService
    {
        int AddCommentToArticle(FirstAppUser user,string commentText,int articleId);

        int AddCommentToDiscussion(FirstAppUser user,string commentText,int discussionId);


    }
}