using AutoMapper;
using FirstApp.Data.Models;
using FirstApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Xsl;
using Microsoft.EntityFrameworkCore.Internal;

namespace FirstApp.Services.ViewModels.Home
{
    public class FavoriteArticleViewModel : IMapFrom<Article>, IHaveCustomMappings
    {

        public int Id { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public string CreatedOn { get; set; }
        public string ImageUrl { get; set; } 
        public string Title { get; set; }
        public string Team { get; set; }


        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Article, FavoriteArticleViewModel>()
                .ForMember(x => x.Category, x => x.MapFrom(y => y.Category.Name))
                .ForMember(x => x.ImageUrl, x => x.MapFrom(y => y.Images.FirstOrDefault().ImageUrl ?? "Images/defaultPic.png"))
                .ForMember(x => x.Category, x => x.MapFrom(y => y.Category.Name))
                .ForMember(x=> x.Team, x => x.MapFrom(y => y.Team.Name));
        }
    }


}
