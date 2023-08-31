using FirstApp.Data.Models;
using FirstApp.Services.ViewModels.Discussion;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.Services.Contracts
{
    public interface IDiscussionService
    {
        ICollection<DiscussionViewModel> AllDiscussions();


        void CreateDiscussion(DiscussionViewModel model);

        DiscussionViewModel DetailsDiscussion(int id);

        Discussion GiveDiscussionById(int discussionId);
    }
}
