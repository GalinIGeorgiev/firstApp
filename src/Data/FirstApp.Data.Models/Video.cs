using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Data.Common;
using Microsoft.AspNetCore.Authentication;

namespace FirstApp.Data.Models
{
    public class Video : BaseModel<int>
    {

        public string Title { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int? TeamId { get; set; }

        public virtual Team Team { get; set; }

        public string VideoUrl { get; set; }

        public string CreatedOn { get; set; } = DateTime.UtcNow.ToString();

        public int? ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
