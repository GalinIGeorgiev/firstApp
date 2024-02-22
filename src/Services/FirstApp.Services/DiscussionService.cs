using AutoMapper;
using FirstApp.Data;
using FirstApp.Data.Models;
using FirstApp.Services.Contracts;
using FirstApp.Services.ViewModels.Discussion;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public IEnumerable<DiscussionViewModel> AllDiscussions()
        {
            var discussions = Db.Discussions.ToList();

            var discussionViewModels = Mapper.Map<IEnumerable<DiscussionViewModel>>(discussions).OrderByDescending(x => x.LastActivity);

            return discussionViewModels;
        }

        public void CreateDiscussion(DiscussionViewModel model)
        {                    

            var discussion = Mapper.Map<Discussion>(model);

            Db.Discussions.Add(discussion);
            Db.SaveChanges();
        }


        public bool DeleteDiscussion(int id)
        {
            var disscussion = GiveDiscussionById(id);
            if (disscussion==null)
            {
                return false;
            }

            disscussion.Comments.Clear();

            Db.Discussions.Remove(disscussion);
            Db.SaveChanges();

            return true;
        }


        public DiscussionViewModel DetailsDiscussion(int Id)
        {
            var discussion = Db.Discussions.Include(x=>x.Comments).ThenInclude(x => x.FirstAppUser).Where(x => x.Id == Id).FirstOrDefault();

            var model = Mapper.Map<DiscussionViewModel>(discussion);

            return model;
        }

        public Discussion GiveDiscussionById(int id)
        {
            var discussion = Db.Discussions.Include(c=> c.Comments).Where(x => x.Id == id).FirstOrDefault();

            return discussion;
        }

    }
}
