using AutoMapper;
using FirstApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace FirstApp.Services.ViewModels.Video
{

    public class VideoViewModel : IMapFrom<Data.Models.Video>, IHaveCustomMappings 
    {

        public int Id { get; set; }

        [Display(Name = "Заглавие")]
        [Required(ErrorMessage = "Полето \"{0}\" e задължително.")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Полето \"{0}\" трябва да бъде текст с минимална дължина {2} и максимална дължина {1}.")]
        public string Title { get; set; }


        public string CreatedOn { get; set; } = DateTime.UtcNow.ToString();

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Полето \"{0}\" e задължително.")]
        public int CategoryId { get; set; }

        [Display(Name = "Отбор")]
        public int? TeamId { get; set; }

        [Display(Name = "Видеo")]
        public ICollection<IFormFile> Videos { get; set; }

        public string VideoUrl { get; set; }



        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CreateVideoViewModel, Data.Models.Video>();

        }
    }
}
