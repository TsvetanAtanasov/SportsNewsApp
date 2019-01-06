using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsNews.Web.MiddleWares
{
    using Areas.Identity.Data;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class SeedAdminMiddleware
    {
        private readonly RequestDelegate _next;

        public SeedAdminMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider provider)
        {
            var userManager = provider.GetService<UserManager<SportsNewsUser>>();
            if (!userManager.Users.Any())
            {
                var roleManager = provider.GetService<RoleManager<IdentityRole>>();
                var adminRoleExists = roleManager.RoleExistsAsync("Administrator").Result;
                if (!adminRoleExists)
                {
                    var result = roleManager.CreateAsync(new IdentityRole("Administrator")).Result;
                    if (!result.Succeeded)
                    {
                        throw new InvalidOperationException();
                    }
                }

                var userRoleExists = roleManager.RoleExistsAsync("User").Result;
                if (!userRoleExists)
                {
                    var result = roleManager.CreateAsync(new IdentityRole("User")).Result;
                    if (!result.Succeeded)
                    {
                        throw new InvalidOperationException();
                    }
                }

                var user = new SportsNewsUser
                {
                    Email = "admin@admin.com",
                    UserName = "admin@admin.com",
                };

                var userResult = await userManager.CreateAsync(user, "12345678");
                if (!userResult.Succeeded)
                {
                    throw new InvalidOperationException();
                }

                var roleResult = await userManager.AddToRoleAsync(user, "Administrator");
                if (!roleResult.Succeeded)
                {
                    throw new InvalidOperationException();
                }
            }

            await this._next(context);
        }
    }
}
