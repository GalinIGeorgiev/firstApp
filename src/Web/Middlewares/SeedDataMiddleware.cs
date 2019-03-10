using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Data;
using FirstApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using FirstApp.Data.Models.Enums;

namespace FirstApp.Web.Middlewares
{
    public class SeedDataMiddleware
    {
        private readonly RequestDelegate _next;

        public SeedDataMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserManager<FirstAppUser> userManager,
            RoleManager<IdentityRole> roleManager, FirstAppContext db)
        {
            SeedRoles(roleManager).GetAwaiter().GetResult();

            SeedUserInRoles(userManager).GetAwaiter().GetResult();

            await _next(context);
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(Role.Admin.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(Role.Admin.ToString()));
            }
        }

        private static async Task SeedUserInRoles(UserManager<FirstAppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new FirstAppUser()
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    FirstName = "Admin",
                };

                var password = "123456";

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Role.Admin.ToString());
                }
            }
        }
    }
}
