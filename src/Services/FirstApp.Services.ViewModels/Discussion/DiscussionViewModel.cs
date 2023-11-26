using AutoMapper;
using FirstApp.Data.Models;
using FirstApp.Services.Mapping;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FirstApp.Services.ViewModels.Discussion
{
    public class DiscussionViewModel : IMapFrom<Data.Models.Discussion>, IHaveCustomMappings    
    {
        public DiscussionViewModel()
        {
            this.Comments= new HashSet<Comment>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето\"{0}\" e задължително.")]
        [Display(Name = "Тема за дискусия")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Полето \"{0}\" трябва да бъде текст с минимална дължина {2} и максимална дължина {1}.")]
        public string Title { get; set; }

        public string CurrentCommentContent { get; set; }

        public string LastActivity { get; set; }


        public ICollection<Comment> Comments { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<DiscussionViewModel, Data.Models.Discussion>()
                .ForMember(x => x.Comments, x => x.Ignore())
                .ForMember(x => x.LastActivity, x => x.Ignore());

            // TODO
            //configuration.CreateMap<Data.Models.Discussion,DiscussionViewModel>()
            //    .ForMember(x=>x.Comments)
        }
    }
}
