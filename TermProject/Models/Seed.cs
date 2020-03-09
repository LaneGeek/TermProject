using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace TermProject.Models
{
    public static class Seed
    {
        public static async Task CreateAdminAccount(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            UserManager<AppUser> userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string firstName = configuration["AdminUser:FirstName"];
            string lastName = configuration["AdminUser:LastName"];
            string email = configuration["AdminUser:Email"];
            string password = configuration["AdminUser:Password"];
            string role = configuration["AdminUser:Role"];

            if (await userManager.FindByEmailAsync(email) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                AppUser user = new AppUser
                {
                    FirstName = firstName,
                    LastName = lastName,
                    UserName = email,
                    Email = email
                };

                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                    Console.WriteLine("No admin user present. New admin user created.");
                }
            }
            else
            {
                Console.WriteLine("Admin user already present. New one not created.");
            }
        }
    }
}
