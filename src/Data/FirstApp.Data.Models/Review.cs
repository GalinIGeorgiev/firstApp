using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Data.Common;

namespace FirstApp.Data.Models
{
    public class Review : BaseModel<int>
    {
        public int Raiting { get; set; }

        public string Comment { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
