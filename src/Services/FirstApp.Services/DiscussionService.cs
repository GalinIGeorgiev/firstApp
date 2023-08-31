using AutoMapper;
using FirstApp.Data;
using FirstApp.Data.Models;
using FirstApp.Services.Contracts;
using FirstApp.Services.ViewModels.Discussion;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Services
{
    public class DiscussionService : IDiscussionService
    {
        private readonly FirstAppContext Db;
        public DiscussionService(FirstAppContext db)
        {
            this.Db = db;
        }
        public ICollection<DiscussionViewModel> AllDiscussions()
        {
            var discussions = Db.Discussions.ToList();

            var discussionViewModels = Mapper.Map<ICollection<DiscussionViewModel>>(discussions);

            return discussionViewModels;
        }

        public void CreateDiscussion(DiscussionViewModel model)
        {           
            var discussion = Mapper.Map<Discussion>(model);

            Db.Discussions.Add(discussion);
            Db.SaveChanges();
        }

        public DiscussionViewModel DetailsDiscussion(int Id)
        {
            var discussion = Db.Discussions.Include(x=>x.Comments).ThenInclude(x => x.FirstAppUser).Where(x => x.Id == Id).FirstOrDefault();

            var model = Mapper.Map<DiscussionViewModel>(discussion);

            return model;
        }

        public Discussion GiveDiscussionById(int id)
        {
            var discussion = Db.Discussions.Where(x => x.Id == id).FirstOrDefault();

            return discussion;
        }

    }
}
