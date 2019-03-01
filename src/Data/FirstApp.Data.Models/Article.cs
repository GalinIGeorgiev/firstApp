using FirstApp.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstApp.Data.Models
{
    public class Article : BaseModel<int>
    {
        public string Content { get; set; }

        public string CreatedOn { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Rating { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Image> Images { get; set; }

    }
}
