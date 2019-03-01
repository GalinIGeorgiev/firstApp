using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.Data.Models
{
    public class Comment
    {
        public string Content { get; set; }

        public int FirstAppUserId { get; set; }
        public FirstAppUser FirstAppUser { get; set; }
        public int? ArticleId { get; set; }
        public Article Article { get; set; }

        public int? DiscussionId { get; set; }
        public Discussion Discussion { get; set; }
    }
}
