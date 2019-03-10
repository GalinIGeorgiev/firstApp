using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public string FirstName { get; set; }

        public string FavoriteSport { get; set; }
        public string FavoriteTeam { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
