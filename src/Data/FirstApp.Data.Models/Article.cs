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
            this.Images = new HashSet<Image>();
            this.Video = new HashSet<Video>();
        }
        public string Content { get; set; }

        public string CreatedOn { get; set; } = DateTime.UtcNow.ToString();

        public string Title { get; set; }

        public decimal Rating =>  RatingCalculator(Reviews) ;


        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Video> Video { get; set; }


        private decimal RatingCalculator(ICollection<Review> reviews)
        {
            decimal rating = ((decimal)reviews.Sum(x => x.Raiting)) / reviews.Count;

            return rating;
        }
    }
}
