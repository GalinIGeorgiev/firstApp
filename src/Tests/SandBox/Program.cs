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
using FunApp.Data.Common;

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
            var context= serviceProvider.GetService<FirstAppContext>();

            var repository = serviceProvider.GetService<DbRepository<Article>>();
            
            var parser = new HtmlParser();
            var webClient = new WebClient { Encoding = Encoding.UTF8 };

            var category = new Category() {Name = "Football"};
            context.AddAsync(category);
            context.SaveChanges();

            var urlPattern = "https://www.sportal.bg/news.php?news=";
            for (int i = 700000; i < 700050; i++)
            {
                var url = urlPattern + i;
                var html = webClient.DownloadString(url);
                var document = parser.ParseDocument(html);
                var content = document.QuerySelector("#news_content")?.TextContent;

                if (content!=null)
                {
                    context.AddAsync(new Article()
                    {
                        Content = content,
                        Category = category
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
