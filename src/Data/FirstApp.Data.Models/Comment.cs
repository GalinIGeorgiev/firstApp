using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Data.Common;

namespace FirstApp.Data.Models
{
    public class Comment : BaseModel<int>
    {
        public string Content { get; set; }

        public string CreatedOn { get; set; } = DateTime.UtcNow.AddHours(3).ToString();

        public int FirstAppUserId { get; set; }
        public FirstAppUser FirstAppUser { get; set; }

        public int? ArticleId { get; set; }
        public Article Article { get; set; }

        public int? DiscussionId { get; set; }
        public Discussion Discussion { get; set; }
    }
}
