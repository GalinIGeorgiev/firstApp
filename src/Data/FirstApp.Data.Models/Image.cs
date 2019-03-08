using FirstApp.Data.Common;

namespace FirstApp.Data.Models
{
    public class Image : BaseModel<int>
    {
        public string ImageUrl { get; set; }

        public int? ArticleId { get; set; }
        public virtual Article Article { get; set; }

    }
}