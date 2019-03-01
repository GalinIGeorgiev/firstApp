namespace FirstApp.Data.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }

    }
}