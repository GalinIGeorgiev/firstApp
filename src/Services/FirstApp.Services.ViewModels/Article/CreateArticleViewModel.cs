using AutoMapper;
using FirstApp.Data.Models;
using FirstApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Xsl;
using Microsoft.AspNetCore.Http;

namespace FirstApp.Services.ViewModels.Articles
{

    public class CreateArticleViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name = "Заглавие")]
        [Required(ErrorMessage = "Полето\"{0}\" e задължително.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Полето \"{0}\" трябва да бъде текст с минимална дължина {2} и максимална дължина {1}.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Полето\"{0}\" e задължително.")]
        public string Content { get; set; }

        public string CreatedOn { get; set; } = DateTime.UtcNow.ToString();

        [Display(Name = "Категория")]
        [Required]
        public int CategoryId { get; set; }

        [Display(Name = "Отбор")]
        [Required]
        public int TeamId { get; set; }

        [Display(Name = "Снимки")]
        public ICollection<IFormFile> Images { get; set; }

        [Display(Name = "Видеа")]
        public ICollection<IFormFile> Videos { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CreateArticleViewModel, Article>()
                .ForMember(x => x.Category, x => x.Ignore())
                .ForMember(x => x.Team, x => x.Ignore())
                .ForMember(x => x.Images, x => x.Ignore());

        }
    }
}
