using FirstApp.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.Data.Models
{
    public class Category:BaseModel<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
