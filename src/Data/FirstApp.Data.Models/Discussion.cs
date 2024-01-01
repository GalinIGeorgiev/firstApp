using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Data.Common;

namespace FirstApp.Data.Models
{
    public class Discussion : BaseModel<int> 
    {
        public Discussion()
        {
            this.Comments = new HashSet<Comment>();
            this.LastActivity = DateTime.UtcNow.AddHours(3).ToString();
        }

        public string Title { get; set; }

        public string LastActivity { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
            this.LastActivity= DateTime.UtcNow.AddHours(3).ToString();
        }
    }
}
