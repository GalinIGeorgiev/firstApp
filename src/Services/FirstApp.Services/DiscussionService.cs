using AutoMapper;
using FirstApp.Data;
using FirstApp.Data.Models;
using FirstApp.Services.Contracts;
using FirstApp.Services.ViewModels.Discussion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstApp.Services
{
    public class DiscussionService : IDiscussionService
    {
        private readonly FirstAppContext Db;
        public DiscussionService(FirstAppContext db)
        {
            this.Db = db;
        }
        public ICollection<Discussion> AllDiscussions()
        {
            var discussions = Db.Discussions.ToList();

            return discussions;
        }

        public void CreateDiscussion(CreateDiscussionViewModel model)
        {
            var discussion = Mapper.Map<Discussion>(model);
            Db.Discussions.Add(discussion);
            Db.SaveChanges();

        }

    }
}
