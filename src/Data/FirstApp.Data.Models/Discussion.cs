using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Data.Common;

namespace FirstApp.Data.Models
{
    public class Discussion:BaseModel<int>
    {
        public Discussion()
        {
                this.Comments= new HashSet<Comment>();
        }
        public string Title { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
