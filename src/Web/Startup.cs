using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FirstApp.Web.Models;
using FirstApp.Data;
using FirstApp.Data.Models;
using FirstApp.Services;
using FirstApp.Services.Contracts;
using FirstApp.Data.Common;
using FirstApp.Services.Mapping;
using FirstApp.Services.ViewModels.Articles;
using FirstApp.Services.ViewModels.Home;
using FirstApp.Web.Middlewares;
using Microsoft.AspNetCore.Authentication.Facebook;

namespace FirstApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(
                options =>
                {
                    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                }); 

            AutoMapperConfig.RegisterMappings(
                typeof(ArticleViewModel).Assembly,
                typeof(Article).Assembly
            );

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

                    services.AddDbContext<FirstAppContext>(options =>
                        options.UseSqlServer(
                            this.Configuration.GetConnectionString("FirstAppContextConnection")));

                    services.AddIdentity<FirstAppUser, IdentityRole>(options =>
                         {
                             options.Password.RequiredLength = 6;
                             options.Password.RequireDigit = false;
                             options.Password.RequireLowercase = false;
                             options.Password.RequireUppercase = false;
                             options.Password.RequireNonAlphanumeric = false;
                             options.Password.RequiredUniqueChars = 0;

                         }

                    )
                        .AddDefaultTokenProviders()
                        .AddDefaultUI()
                        .AddEntityFrameworkStores<FirstAppContext>();

                    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

                    //facebook authentication
                    services.AddAuthentication().AddFacebook(facebookOptions =>
                    {
                        facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                        facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];

                    });


                    //Application Services
                    services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
                    services.AddScoped<IArticleService, ArticleService>();
                    services.AddScoped<ICategoryService, CategoryService>();
                    services.AddScoped<ITeamService, TeamService>();
                    services.AddScoped<IImageService, ImageService>();
                    services.AddScoped<IVideoService, VideoService>();
                    services.AddScoped<ICommentService, CommentService>();
                    services.AddScoped<IDiscussionService, DiscussionService>();

                }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseDatabaseErrorPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.UseCookiePolicy();

                app.UseAuthentication();
                app.UseStaticFiles();

                app.UseSeedDataMiddleware();

                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "areas",
                        template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
            }
        }
    }

