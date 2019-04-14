using FirstApp.Data.Models;
using FirstApp.Services.ViewModels.Discussion;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.Services.Contracts
{
    public interface IDiscussionService
    {
        IndexDiscussionsViewModel AllDiscussions();


        void CreateDiscussion(CreateDiscussionViewModel model);

    }
}
