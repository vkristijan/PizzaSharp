using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActivelyServedPizza.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ActivelyServedPizza.Models
{
    public static class ApplicationRoles
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                string roleName = Roles.Admin;
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
                
            }
        }
    }
}
