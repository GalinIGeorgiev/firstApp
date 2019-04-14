using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.Services.ViewModels.Discussion
{
    public class IndexDiscussionsViewModel
    {
        public ICollection<DiscussionViewModel> discussionViewModels { get; set; }
    }
}
