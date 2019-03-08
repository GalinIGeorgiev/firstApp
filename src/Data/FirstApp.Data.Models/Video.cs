using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Data.Common;
using Microsoft.AspNetCore.Authentication;

namespace FirstApp.Data.Models
{
    public class Video : BaseModel<int>
    {

        public string Sport { get; set; }
        public string Team { get; set; }

        public string VideoUrl { get; set; }

        public int? ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
