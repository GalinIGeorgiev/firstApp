using FirstApp.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace FirstApp.Data.Models
{
    public class Article : BaseModel<int>
    {
        public Article()
        {
            this.Reviews = new HashSet<Review>();
            this.Comments = new HashSet<Comment>();
            this.Images = new HashSet<Image>();
            this.Videos = new HashSet<Video>();
        }
        public string Content { get; set; }

        public string CreatedOn { get; set; } = DateTime.UtcNow.AddHours(2).ToString();

        public string Title { get; set; }

        public decimal Rating => RatingCalculator(Reviews);


        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int? TeamId { get; set; }

        public virtual Team Team { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }


        private decimal RatingCalculator(ICollection<Review> reviews)
        {
            decimal rating;
            if (reviews.Count == 0)
            {
                rating = 0;
            }
            else
            {
                rating = ((decimal)reviews.Sum(x => x.Raiting)) / reviews.Count;
            }

            return rating;
        }
    }
}
