using AutoMapper;
using FirstApp.Data.Models;
using FirstApp.Services.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace FirstApp.Services.ViewModels.Articles
{
    public class DetailsArticleViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public DetailsArticleViewModel()
        {
            this.Comments = new List<Comment>();
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string CreatedOn { get; set; }

        public string Category { get; set; }

        public string Team { get; set; }

        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }

        public string CurrentCommentContent { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Article, DetailsArticleViewModel>()
                .ForMember(x => x.Team, y => y.MapFrom(x => x.Team.Name))
                .ForMember(x => x.ImageUrl, y => y.MapFrom(x => x.Images.FirstOrDefault().ImageUrl))
                .ForMember(x => x.VideoUrl, y => y.MapFrom(x => x.Videos.FirstOrDefault().VideoUrl))
                .ForMember(x => x.Comments, y => y.MapFrom(x => x.Comments));
        }
    }
}
