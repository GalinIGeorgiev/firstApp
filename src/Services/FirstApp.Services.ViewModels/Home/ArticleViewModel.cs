using AutoMapper;
using FirstApp.Data.Models;
using FirstApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace FirstApp.Services.ViewModels.Home
{
    public class ArticleViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public string Content { get; set; }
        public string Category { get; set; }
        public string CreatedOn { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }


        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            // configuration.CreateMap<Joke, IndexJokeViewModel>().ForMember(x => x.CategoryName, x => x.MapFrom(j => j.Category.Name))

            configuration.CreateMap<Article, ArticleViewModel>()
                .ForMember(x => x.Category, x => x.MapFrom(y => y.Category.Name))
                .ForMember(x => x.ImageUrl, x => x.MapFrom(y => y.Images.FirstOrDefault().ImageUrl))
                .ForMember(x => x.Category, x => x.MapFrom(y => y.Category.Name));
        }
    }


}
