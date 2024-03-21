using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FirstApp.Data.Models;
using FirstApp.Services.Mapping;

namespace FirstApp.Services.ViewModels.Category

{
    public class CreateCategoryViewModel : IMapFrom<FirstApp.Data.Models.Category> , IHaveCustomMappings
    {
        [Display(Name = "Име на категория")]
        [Required(ErrorMessage = "Полето \"{0}\" e задължително.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Полето \"{0}\" трябва да бъде текст с минимална дължина {2} и максимална дължина {1}.")]
        public string Name { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<
                    CreateCategoryViewModel, Data.Models.Category>()
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name));
        }
    }
}
