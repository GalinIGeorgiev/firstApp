using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FirstApp.Data
{
    public class FirstAppContext : IdentityDbContext<FirstAppUser> 
    {
        public FirstAppContext(DbContextOptions<FirstAppContext> options)
            : base(options)
        {

        }
 
        public DbSet<Article> Articles { get; set; }    
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Comment> Comments { get; set; }

      

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        
    }
}
