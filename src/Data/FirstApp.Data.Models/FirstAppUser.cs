using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FirstApp.Data.Models
{
    // Add profile data for application users by adding properties to the FirstAppUser class
    public class FirstAppUser : IdentityUser
    {
        public FirstAppUser()
        {
            this.Comments = new HashSet<Comment>();
            this.Reviews = new HashSet<Review>();
        }
        [MaxLength(20)]
        [MinLength(2)]
        public string FirstName { get; set; }

        public string FavoriteSport { get; set; }
        public string FavoriteTeam { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
