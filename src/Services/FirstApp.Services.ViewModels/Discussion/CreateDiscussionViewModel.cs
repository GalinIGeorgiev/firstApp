using FirstApp.Data.Models;
using FirstApp.Data;
using FirstApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.Services.ViewModels.Discussion
{
    public class CreateDiscussionViewModel : IMapFrom<FirstApp.Data.Models.Discussion>
    {


        public string Title { get; set; }

        public ICollection<Comment> Comments { get; set; }


    }
}
