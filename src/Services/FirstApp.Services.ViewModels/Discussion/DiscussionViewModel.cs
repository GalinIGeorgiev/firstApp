using FirstApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.Services.ViewModels.Discussion
{
    public class DiscussionViewModel : IMapTo<Data.Models.Discussion> 
    {
        public int id { get; set; }
        public string Title { get; set; }
    }
}
