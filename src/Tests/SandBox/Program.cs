using AngleSharp;
using CommandLine;
using FirstApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using AngleSharp.Html.Parser;
using FirstApp.Data.Models;
using System.Collections.Generic;
using FirstApp.Data.Common;
using Microsoft.EntityFrameworkCore.Internal;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);



            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;

                SandBoxCode(serviceProvider);
            }
        }

        private static void SandBoxCode(IServiceProvider serviceProvider)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var context = serviceProvider.GetService<FirstAppContext>();

            var repository = serviceProvider.GetService<DbRepository<Article>>();

            var parser = new HtmlParser();
            var webClient = new WebClient { Encoding = Encoding.UTF8 };

            //category
            var category = new Category() { Name = "Football" };
            var category2 = new Category() { Name = "Formula 1" };
            var category3 = new Category() { Name = "Box" };

            List<Category> categories = new List<Category>()
            {
                category,category2,category3
            };

            context.AddAsync(category);
            context.AddAsync(category2);
            context.AddAsync(category3);

            //images
            Image image = new Image()
            {
                ImageUrl =
                    "https://media.gettyimages.com/photos/liver" +
                    "pool" +
                    "-captain-steven-gerrard-lifts-the-european-cup-after-won-picture-id53158414"
            };
            Image image2 = new Image()
            {
                ImageUrl =
                    "https://cdn.vox-cdn.com/uploads/chorus_asset/file/11599051/20180626_formula1_frenchgp_vladsavov00038.jpg"
            };
            Image image3 = new Image()
            {
                ImageUrl =
                    "https://images.gulfnews.com/201811/Heavyweight%20champion%20Muhammad%20Ali_resources1.jpg"
            };
            List<Image> images = new List<Image>()
            {
                image,image2,image3
            };


            context.AddAsync(image);
            context.AddAsync(image2);
            context.AddAsync(image3);

            //Teams
            Team team1 = new Team()
            {
                Name = "Liverpool"
            };
            Team team2 = new Team()
            {
                Name = "Red Bull Racing"
            }; Team team3 = new Team()
            {
                Name = "Muhammad Ali"
            };

            List<Team> teams = new List<Team>()
            {
                team1,team2,team3
            };

            context.AddAsync(team1);
            context.AddAsync(team2);
            context.AddAsync(team3);

            context.SaveChanges();

            //article
            var urlPattern = "https://www.sportal.bg/news.php?news=";
            for (int i = 700100; i < 700150; i++)
            {
                var url = urlPattern + i;
                var html = webClient.DownloadString(url);
                var document = parser.ParseDocument(html);
                var content = document.QuerySelector("#news_content")?.TextContent;

                if (content != null)
                {
                    context.AddAsync(new Article()
                    {
                        Content = content,
                        Category = categories[i % 3],
                        CreatedOn = DateTime.UtcNow.ToString(),
                        Title = "This is Title!!!",
                        Images = new List<Image>(images.Take(i % 3)),
                        Team = teams[i%3]
                        
                    });

                }

                context.SaveChanges();
                Console.WriteLine("---");
            }


        }


        private static void ConfigureServices(ServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            services.AddDbContext<FirstAppContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
        }
    }
}
